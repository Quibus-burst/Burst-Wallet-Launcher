'Class provided to set Settings file in same directory as launcher.
'May be disposed later on.
'
Imports System.Configuration

Public Class NewCustomProvider
    Inherits SettingsProvider

    Private g_sSettingsFile As String = My.Application.Info.DirectoryPath + "\Settings.ini"
    Private _appName As String

    Public Overrides Property ApplicationName As String
        Get
            Return Reflection.Assembly.GetExecutingAssembly().GetName().Name
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Overrides Sub Initialize(ByVal name As String, ByVal config As Specialized.NameValueCollection)
        MyBase.Initialize("CustomProviderDemo", Nothing)
    End Sub

    Public Overrides Function GetPropertyValues(ByVal context As SettingsContext, ByVal collection As System.Configuration.SettingsPropertyCollection) As System.Configuration.SettingsPropertyValueCollection
        Dim settingsFileContents As String()
        Dim settingsCollection As SettingsPropertyValueCollection = New SettingsPropertyValueCollection


        If IO.File.Exists(g_sSettingsFile) Then
            settingsFileContents = IO.File.ReadAllLines(g_sSettingsFile)
        Else
            settingsFileContents = New String() {}
        End If

        For Each prop As SettingsProperty In collection

            Dim prop1 As SettingsProperty = prop

            Dim pval As New SettingsPropertyValue(prop)
            settingsCollection.Add(pval)

            Dim propLine = settingsFileContents.FirstOrDefault(Function(line) line.Split(","c)(0).ToLower = prop1.Name.ToLower)

            If propLine IsNot Nothing Then
                Dim propValue As String = propLine.Split(","c)(1)
                Dim propType As TypeCode = CType(propLine.Split(","c)(2), TypeCode)

                pval.PropertyValue = Convert.ChangeType(propValue, propType)
            Else
                pval.PropertyValue = prop.DefaultValue 'Activator.CreateInstance(prop.PropertyType)

            End If

        Next
        Return settingsCollection
    End Function

    Public Overrides Sub SetPropertyValues(ByVal context As System.Configuration.SettingsContext, ByVal collection As System.Configuration.SettingsPropertyValueCollection)
        Dim settings As New List(Of String)

        For Each pval As SettingsPropertyValue In collection
            Dim line As String = Nothing

            line = pval.Name + "," + pval.PropertyValue.ToString + "," + CInt(Type.GetTypeCode(pval.PropertyValue.GetType)).ToString
            settings.Add(line)
        Next

        IO.File.WriteAllLines(g_sSettingsFile, settings.ToArray)
    End Sub

End Class
Namespace My
    <SettingsProvider(GetType(NewCustomProvider))>
    Friend Class MySettings

    End Class
End Namespace