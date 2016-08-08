Public Class uscInicial

#Region "Declarações"
    Private objNegocio As negPomodoro
#End Region

#Region "Contrutor"
    Public Sub New(p_objNegocio As negPomodoro)
        Try
            InitializeComponent()
            objNegocio = p_objNegocio
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"
    Public Event evOk(sender As Object, obPomodoros As List(Of clsPomodoro))

    Private Sub imgPlay_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgPlay.MouseUp
        Try
            Call sbPlay()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub imgAdd_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgAdd.MouseUp
        Try
            Call sbAdicionaTarefa(cmbTarefas.SelectedIndex)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub objAuxItem_evRemover(sender As Object, p_objTag As Object)
        Try
            Call sbRemoverTarefa(cmbTarefas.SelectedIndex, sender)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Pomodoro Desktop")
        End Try
    End Sub

    Private Sub sldQuantidade_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Double)) Handles sldQuantidade.ValueChanged
        Try
            Call sbMontaCombo(sldQuantidade.Value)
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

    Private Sub cmbTarefas_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbTarefas.SelectionChanged
        Try
            Call sbSelcionaPomodoro(cmbTarefas.SelectedIndex)
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
        Try

            sldQuantidade.Value = objNegocio.Pomodoros.Count
            Call sbMontaCombo(objNegocio.Pomodoros.Count)

        Catch ex As Exception
            Throw New Exception("Erro ao carrgar a tela.", ex)
        End Try
    End Sub

    Private Sub sbMontaCombo(p_intQuantidade As Integer)
        Try

            If cmbTarefas IsNot Nothing Then

                If p_intQuantidade > objNegocio.Pomodoros.Count Then
                    For i = 0 To p_intQuantidade - objNegocio.Pomodoros.Count
                        objNegocio.Pomodoros.Add(New clsPomodoro)
                    Next
                End If

                cmbTarefas.Items.Clear()

                For i = 0 To p_intQuantidade - 1
                    cmbTarefas.Items.Add("Pomodoro " & i + 1)
                Next

                cmbTarefas.SelectedIndex = 0
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub sbSelcionaPomodoro(p_intIndex As Integer)

        Dim objAuxItem As uscItemLista

        Try
            If p_intIndex > -1 Then
                stkTarefas.Children.Clear()

                For Each Item As clsTarefa In objNegocio.Pomodoros(p_intIndex).Tarefas
                    objAuxItem = New uscItemLista(Item.Descricao, Item) With {.Margin = New Thickness(2)}
                    AddHandler objAuxItem.evRemover, AddressOf objAuxItem_evRemover
                    stkTarefas.Children.Add(objAuxItem)
                Next
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub sbAdicionaTarefa(p_intIndex As Integer)

        Dim objAuxItem As uscItemLista

        Try

            If p_intIndex > -1 Then
                If txtTarefa.Text.Trim <> "" Then

                    objNegocio.Pomodoros(p_intIndex).Tarefas.Add(New clsTarefa() With {.Concluida = False, .Descricao = txtTarefa.Text})

                    objAuxItem = New uscItemLista(objNegocio.Pomodoros(p_intIndex).Tarefas.Last.Descricao, objNegocio.Pomodoros(p_intIndex).Tarefas.Last) With {.Margin = New Thickness(2)}
                    AddHandler objAuxItem.evRemover, AddressOf objAuxItem_evRemover
                    stkTarefas.Children.Add(objAuxItem)

                Else
                    MsgBox("A tarefa deve ter uma descrição.", MsgBoxStyle.Exclamation, "Pomodoro Desktop")
                End If
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub sbRemoverTarefa(p_intIndex As Integer, p_objTarefa As uscItemLista)

        Try
            If p_intIndex > -1 Then
                stkTarefas.Children.Remove(p_objTarefa)
                objNegocio.Pomodoros(p_intIndex).Tarefas.Remove(p_objTarefa.Tag)
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub sbPlay()
        Try
            If CInt(sldQuantidade.Value) < objNegocio.Pomodoros.Count Then
                objNegocio.Pomodoros.RemoveRange(sldQuantidade.Value - 1, objNegocio.Pomodoros.Count - CInt(sldQuantidade.Value))
            End If
            objNegocio.sbSalvarPomodoro()
            RaiseEvent evOk(Me, objNegocio.Pomodoros)
        Catch ex As Exception
            Throw New Exception("Erro ao iniciar.", ex)
        End Try
    End Sub

    Private Sub sbLimpar()
        Try
            objNegocio.Pomodoros = New List(Of clsPomodoro)
            objNegocio.Pomodoros.Add(New clsPomodoro)
        Catch ex As Exception
            Throw New Exception("Erro ao iniciar.", ex)
        End Try
    End Sub
#End Region

#Region "Propriedades"

#End Region

End Class
