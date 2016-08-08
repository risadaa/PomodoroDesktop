Public Class uscConfig

#Region "Declarações"
    Private objNegocio As negPomodoro
    Private intestado As Integer
#End Region

#Region "Contrutor"
    Public Sub New(p_objNegocio As negPomodoro, p_intEstado As Integer)
        Try
            InitializeComponent()
            objNegocio = p_objNegocio
            intestado = p_intEstado
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"
    Public Event evOk(sender As Object, objConfig As clsPomodoroConfig)

    Private Sub imgSalvar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgSalvar.MouseUp
        Try
            Call sbSalvar()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgSair_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgSair.MouseUp
        Try
            RaiseEvent evOk(Me, objNegocio.Configuracao)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub uscConfig_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Try
            Call sbCarregarTela()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub
#End Region

#Region "Funções e Subrotinas"
    Private Sub sbCarregarTela()
        Try

            chkSempreVisivel.IsChecked = objNegocio.Configuracao.SempreVisivel
            chkAlerta.IsChecked = objNegocio.Configuracao.AlertaSonoro
            txtTempoPomodoro.Text = objNegocio.Configuracao.TempoPomodoro
            txtTempoIntervaloMenor.Text = objNegocio.Configuracao.TempoIntervaloMenor
            txtTempoIntervaloMaior.Text = objNegocio.Configuracao.TempoIntervaloMaior

            If intestado <> 0 Then
                txtTempoPomodoro.IsEnabled = False
                txtTempoIntervaloMenor.IsEnabled = False
                txtTempoIntervaloMaior.IsEnabled = False
            End If

        Catch ex As Exception
            Throw New Exception("Erro ao carrgar a tela.", ex)
        End Try
    End Sub

    Private Sub sbSalvar()
        Try
            objNegocio.Configuracao.SempreVisivel = chkSempreVisivel.IsChecked
            objNegocio.Configuracao.AlertaSonoro = chkAlerta.IsChecked
            objNegocio.Configuracao.TempoPomodoro = txtTempoPomodoro.Text
            objNegocio.Configuracao.TempoIntervaloMenor = txtTempoIntervaloMenor.Text
            objNegocio.Configuracao.TempoIntervaloMaior = txtTempoIntervaloMaior.Text
            objNegocio.sbSalvarconfiguracao()
            MsgBox("Configuração salva com sucesso.", MsgBoxStyle.OkOnly, "Pomodoro Desktop")
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Propriedades"

#End Region
End Class
