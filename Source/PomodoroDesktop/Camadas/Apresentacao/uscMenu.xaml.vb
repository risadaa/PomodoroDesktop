Public Class uscMenu
#Region "Declarações"
    Private objPomodoro As clsPomodoro
    Private intEstado As Integer
#End Region

#Region "Contrutor"
    Public Sub New(p_objPomodoro As clsPomodoro, p_intEstado As Integer)
        Try
            InitializeComponent()
            objPomodoro = p_objPomodoro
            intEstado = p_intEstado
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"
    Public Event evOk(sender As Object, intBotao As Integer)

    Private Sub imgSair_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgSair.MouseUp
        Try
            RaiseEvent evOk(Me, 0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgNota_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgNota.MouseUp
        Try
            RaiseEvent evOk(Me, 1)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgStop_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgStop.MouseUp
        Try
            RaiseEvent evOk(Me, 3)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgFechar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgFechar.MouseUp
        Try
            RaiseEvent evOk(Me, 4)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgConfig_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgConfig.MouseUp
        Try
            RaiseEvent evOk(Me, 2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgAbout_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgAbout.MouseUp
        Try
            RaiseEvent evOk(Me, 5)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub uscInicial_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Try
            Call sbCarregarTela()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub
#End Region

#Region "Funções e Subrotinas"
    Private Sub sbCarregarTela()

        Dim objAuxItem As uscItemMarcar

        Try

            If intEstado = 1 Then
                For Each Item As clsTarefa In objPomodoro.Tarefas
                    objAuxItem = New uscItemMarcar(Item.Descricao, Item) With {.Margin = New Thickness(2)}
                    stkTarefas.Children.Add(objAuxItem)
                Next
            Else
                For Each Item As clsTarefa In objPomodoro.TarefasIntervalo
                    objAuxItem = New uscItemMarcar(Item.Descricao, Item) With {.Margin = New Thickness(2)}
                    stkTarefas.Children.Add(objAuxItem)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("Erro ao carrgar a tela.", ex)
        End Try
    End Sub
#End Region

#Region "Propriedades"

#End Region
End Class
