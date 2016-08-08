Public Class uscItemLista

#Region "Declarações"
#End Region

#Region "Contrutor"
    Public Sub New(p_strDescricao As String, p_objTag As Object)

        Try
            InitializeComponent()
            Me.Tag = p_objTag
            lblDescricao.Text = p_strDescricao
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region

#Region "Eventos"
    Public Event evRemover(sender As Object, p_objTag As Object)

    Private Sub imgRemover_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles imgRemover.MouseUp
        Try
            RaiseEvent evRemover(Me, Me.Tag)
        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

#Region "Funções e Subrotinas"

#End Region

#Region "Propriedades"
    Public Property Descricao As String
        Get
            Return lblDescricao.Text
        End Get
        Set(value As String)
            lblDescricao.Text = value
        End Set
    End Property

#End Region

End Class
