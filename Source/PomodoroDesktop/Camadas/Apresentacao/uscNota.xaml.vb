Public Class uscNota

#Region "Declarações"
    Private objPomodoro As clsPomodoro

#End Region

#Region "Contrutor"
    Public Sub New(p_objPomodoro As clsPomodoro)
        Try
            InitializeComponent()
            objPomodoro = p_objPomodoro
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"
    Public Event evOk(sender As Object, objPomodoro As clsPomodoro)

    Private Sub imgPlay_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgPlay.MouseUp
        Try
            Call sbSalvar()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgAdd_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgAdd.MouseUp
        Try
            Call sbAdicionaTarefa()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub objAuxItem_evRemover(sender As Object, p_objTag As Object)
        Try
            Call sbRemoverTarefa(sender)
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

    Private Sub imgLimpar_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgLimpar.MouseUp
        Try
            Call sbLimpar()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub
#End Region

#Region "Funções e Subrotinas"
    Private Sub sbCarregarTela()

        Dim objAuxItem As uscItemLista

        Try

            For Each Item As clsTarefa In objPomodoro.TarefasIntervalo
                objAuxItem = New uscItemLista(Item.Descricao, Item) With {.Margin = New Thickness(2)}
                AddHandler objAuxItem.evRemover, AddressOf objAuxItem_evRemover
                stkTarefas.Children.Add(objAuxItem)
            Next

        Catch ex As Exception
            Throw New Exception("Erro ao carrgar a tela.", ex)
        End Try
    End Sub

    Private Sub sbAdicionaTarefa()

        Dim objAuxItem As uscItemLista

        Try


            If txtTarefa.Text.Trim <> "" Then

                objPomodoro.TarefasIntervalo.Add(New clsTarefa() With {.Concluida = False, .Descricao = txtTarefa.Text})

                objAuxItem = New uscItemLista(objPomodoro.TarefasIntervalo.Last.Descricao, objPomodoro.TarefasIntervalo.Last) With {.Margin = New Thickness(2)}
                AddHandler objAuxItem.evRemover, AddressOf objAuxItem_evRemover
                stkTarefas.Children.Add(objAuxItem)

            Else
                MsgBox("A tarefa deve ter uma descrição.", MsgBoxStyle.Exclamation, "Pomodoro Desktop")
            End If


        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub sbRemoverTarefa(p_objTarefa As uscItemLista)

        Try

            stkTarefas.Children.Remove(p_objTarefa)
            objPomodoro.TarefasIntervalo.Remove(p_objTarefa.Tag)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub sbSalvar()
        Try
            RaiseEvent evOk(Me, objPomodoro)
        Catch ex As Exception
            Throw New Exception("Erro ao iniciar.", ex)
        End Try
    End Sub

    Private Sub sbLimpar()
        Try
            objPomodoro.TarefasIntervalo = New List(Of clsTarefa)
            objPomodoro.TarefasIntervalo.Add(New clsTarefa)
        Catch ex As Exception
            Throw New Exception("Erro ao iniciar.", ex)
        End Try
    End Sub
#End Region

#Region "Propriedades"

#End Region

End Class
