Public Class uscItemMarcar

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
    Public Event evMarcar(sender As Object, p_objTag As Object)

    Private Sub chkMarcar_Checked(sender As Object, e As RoutedEventArgs) Handles chkMarcar.Checked
        Try
            DirectCast(Me.Tag, clsTarefa).Concluida = chkMarcar.IsChecked
            RaiseEvent evMarcar(Me, Me.Tag)
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
