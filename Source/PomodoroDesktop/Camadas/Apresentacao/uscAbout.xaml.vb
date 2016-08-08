Public Class uscAbout

#Region "Declarações"
#End Region

#Region "Contrutor"
    Public Sub New()
        Try
            InitializeComponent()
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"
    Public Event evOk(sender As Object)

    Private Sub imgSair_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgSair.MouseUp
        Try
            RaiseEvent evOk(Me)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub
#End Region

#Region "Funções e Subrotinas"

#End Region

#Region "Propriedades"

#End Region

End Class
