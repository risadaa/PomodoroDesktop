'    Pomodoro Desktop, a simple pomodoro timer For windows desktop.
'    Copyright(C) 2016  Kelvys Boniek Pantaleão
'    Contact: contato@kelvysb.com

'    This program Is free software: you can redistribute it And/Or modify
'    it under the terms Of the GNU General Public License As published by
'    the Free Software Foundation, either version 3 Of the License, Or
'    (at your option) any later version.

'    This program Is distributed In the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty Of
'    MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License For more details.

'    You should have received a copy Of the GNU General Public License
'    along with this program.  If Not, see < http: //www.gnu.org/licenses/>.

Imports System.IO

Public Class negPomodoro

#Region "Declarações"
    Private objConfiguracao As clsPomodoroConfig
    Private objPomodoros As List(Of clsPomodoro)
#End Region

#Region "Contrutor"
    Public Sub New()
        Try
            Call sbCarregarConfiguracao()
            Call sbCarregarPomodoro()
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"

#End Region

#Region "Funções e Subrotinas"
    Public Sub sbCarregarConfiguracao()
        Try

            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "cfgPomodoro.cfg") = True Then
                objConfiguracao = New clsPomodoroConfig(XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory & "cfgPomodoro.cfg"))
            Else
                objConfiguracao = New clsPomodoroConfig
                Call sbSalvarconfiguracao()
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub sbSalvarconfiguracao()
        Try
            objConfiguracao.fnToXml.Save(System.AppDomain.CurrentDomain.BaseDirectory & "cfgPomodoro.cfg")
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub sbCarregarPomodoro()

        Dim objAuxPomodoros As XDocument

        Try

            If File.Exists(System.AppDomain.CurrentDomain.BaseDirectory & "Pomodoro.xml") = True Then
                objAuxPomodoros = XDocument.Load(System.AppDomain.CurrentDomain.BaseDirectory & "Pomodoro.xml")
                objPomodoros = New List(Of clsPomodoro)
                For i = 0 To objAuxPomodoros.<Pomodoros>.<Pomodoro>.Count - 1
                    objPomodoros.Add(New clsPomodoro(New XDocument(objAuxPomodoros.<Pomodoros>.<Pomodoro>(i))))
                Next
            Else
                objPomodoros = New List(Of clsPomodoro)
                objPomodoros.Add(New clsPomodoro)
                Call sbSalvarPomodoro()
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub sbSalvarPomodoro()

        Dim objAuxPomodoros As XDocument

        Try

            objAuxPomodoros = New XDocument(<Pomodoros></Pomodoros>)
            For Each Pomodoro As clsPomodoro In objPomodoros
                objAuxPomodoros.<Pomodoros>.First.Add(Pomodoro.fnToXml.Elements)
            Next

            objAuxPomodoros.Save(System.AppDomain.CurrentDomain.BaseDirectory & "Pomodoro.xml")

        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Propriedades"
    ''' <summary>
    ''' Configuração
    ''' </summary>
    ''' <returns></returns>
    Public Property Configuracao() As clsPomodoroConfig
        Get
            Return objConfiguracao
        End Get
        Set(ByVal value As clsPomodoroConfig)
            objConfiguracao = value
        End Set
    End Property

    ''' <summary>
    ''' Pomodoros
    ''' </summary>
    ''' <returns></returns>
    Public Property Pomodoros() As List(Of clsPomodoro)
        Get
            Return objPomodoros
        End Get
        Set(ByVal value As List(Of clsPomodoro))
            objPomodoros = value
        End Set
    End Property
#End Region

End Class
