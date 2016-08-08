

''' <summary>
''' Classe clsPomodoro
''' Autor: Kelvysb
''' Data: 03/08/2016
''' Finalidade: Classe do pomodoro
''' Cliente: Kelvys
''' Tarefa: 0000
''' </summary>
''' <remarks></remarks>
Public Class clsPomodoro

#Region "Declarações"
    Private blnConcluido As Boolean
    Private strInicio As String
    Private strFim As String
    Private intDuracao As Integer
    Private objTarefas As List(Of clsTarefa)
    Private objTarefasIntervalo As List(Of clsTarefa)
#End Region

#Region "Contrutores"
    Public Sub New()
        Try
            blnConcluido = False
            strInicio = ""
            strFim = ""
            intDuracao = 0
            objTarefas = New List(Of clsTarefa)
            objTarefasIntervalo = New List(Of clsTarefa)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New(p_xmlEntrada As XDocument)
        Try
            Call sbMontaPorXml(p_xmlEntrada)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Funçoes e Subrotinas"
    ''' <summary>
    ''' Converte o objeto em Xml
    ''' </summary>
    ''' <remarks></remarks>
    Public Function fnToXml() As XDocument
        Dim Retorno As XDocument
        Try

            Retorno = New XDocument(<Pomodoro></Pomodoro>)

            Retorno.<Pomodoro>.First.Add(<Concluido><%= blnConcluido.ToString.Trim.ToUpper %></Concluido>)
            Retorno.<Pomodoro>.First.Add(<Inicio><%= strInicio.Trim %></Inicio>)
            Retorno.<Pomodoro>.First.Add(<Fim><%= strFim.Trim %></Fim>)
            Retorno.<Pomodoro>.First.Add(<Duracao><%= intDuracao %></Duracao>)

            Retorno.<Pomodoro>.First.Add(<Tarefas></Tarefas>)
            For i = 0 To objTarefas.Count - 1
                Retorno.<Pomodoro>.<Tarefas>.First.Add(objTarefas(i).fnToXml.Elements)
            Next


            Retorno.<Pomodoro>.First.Add(<TarefasIntervalo></TarefasIntervalo>)
            For i = 0 To objTarefasIntervalo.Count - 1
                Retorno.<Pomodoro>.<TarefasIntervalo>.First.Add(objTarefasIntervalo(i).fnToXml.Elements)
            Next

            Return Retorno

        Catch Ex As Exception
            Throw Ex
        End Try
    End Function

    ''' <summary>
    ''' Cria o objeto apartir de um xml
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub sbMontaPorXml(p_xmlEntrada As XDocument)
        Try

            blnConcluido = IIf(p_xmlEntrada.<Pomodoro>.<Concluido>.Value.Trim.ToUpper = "TRUE", True, False)
            strInicio = p_xmlEntrada.<Pomodoro>.<Inicio>.Value
            strFim = p_xmlEntrada.<Pomodoro>.<Fim>.Value
            intDuracao = CInt(p_xmlEntrada.<Pomodoro>.<Duracao>.Value)
            objTarefas = New List(Of clsTarefa)
            For i = 0 To p_xmlEntrada.<Pomodoro>.<Tarefas>.<Tarefa>.Count - 1
                objTarefas.Add(New clsTarefa(New XDocument(p_xmlEntrada.<Pomodoro>.<Tarefas>.<Tarefa>(i))))
            Next
            objTarefasIntervalo = New List(Of clsTarefa)
            For i = 0 To p_xmlEntrada.<Pomodoro>.<TarefasIntervalo>.<TarefasIntervalo>.Count - 1
                objTarefasIntervalo.Add(New clsTarefa(New XDocument(p_xmlEntrada.<Pomodoro>.<TarefasIntervalo>.<TarefasIntervalo>(i))))
            Next

        Catch Ex As Exception
            Throw Ex
        End Try
    End Sub

    ''' <summary>
    ''' Cria um clone do objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Clone() As clsPomodoro
        Try

            Return New clsPomodoro(fnToXml)

        Catch Ex As Exception
            Throw Ex
        End Try
    End Function


#End Region

#Region "Propriedades"
    ''' <summary>
    ''' Se a o pomodoro foi concluido
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Concluido() As Boolean
        Get
            Return blnConcluido
        End Get
        Set(ByVal p_blnConcluido As Boolean)
            blnConcluido = p_blnConcluido
        End Set
    End Property

    ''' <summary>
    ''' Data Hora do inicio da Tarefa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Inicio() As String
        Get
            Return strInicio
        End Get
        Set(ByVal p_strInicio As String)
            strInicio = p_strInicio
        End Set
    End Property

    ''' <summary>
    ''' Data Hora do Fim da Tarefa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fim() As String
        Get
            Return strFim
        End Get
        Set(ByVal p_strFim As String)
            strFim = p_strFim
        End Set
    End Property

    ''' <summary>
    ''' Duracao do pomodoro
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Duracao() As Integer
        Get
            Return intDuracao
        End Get
        Set(ByVal p_intDuracao As Integer)
            intDuracao = p_intDuracao
        End Set
    End Property

    ''' <summary>
    ''' Tarefas do pomodoro
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tarefas() As List(Of clsTarefa)
        Get
            Return objTarefas
        End Get
        Set(ByVal p_objTarefas As List(Of clsTarefa))
            objTarefas = p_objTarefas
        End Set
    End Property

    ''' <summary>
    ''' Tarefas do proximo intervalo
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TarefasIntervalo() As List(Of clsTarefa)
        Get
            Return objTarefasIntervalo
        End Get
        Set(ByVal p_objTarefasIntervalo As List(Of clsTarefa))
            objTarefasIntervalo = p_objTarefasIntervalo
        End Set
    End Property

#End Region

End Class

''' <summary>
''' Classe clsTarefa
''' Autor: Kelvysb
''' Data: 03/08/2016
''' Finalidade: Classe de Tarefa
''' Cliente: Kelvys
''' Tarefa: 0000
''' </summary>
''' <remarks></remarks>
Public Class clsTarefa

#Region "Declarações"
    Private blnConcluida As Boolean
    Private strDescricao As String
    Private strInicio As String
    Private strFim As String
#End Region

#Region "Contrutores"
    Public Sub New()
        Try
            blnConcluida = False
            strDescricao = ""
            strInicio = ""
            strFim = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New(p_xmlEntrada As XDocument)
        Try
            Call sbMontaPorXml(p_xmlEntrada)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Funçoes e Subrotinas"
    ''' <summary>
    ''' Converte o objeto em Xml
    ''' </summary>
    ''' <remarks></remarks>
    Public Function fnToXml() As XDocument
        Dim Retorno As XDocument
        Try

            Retorno = New XDocument(<ClsTarefa></ClsTarefa>)

            Retorno.<ClsTarefa>.First.Add(<Concluida><%= blnConcluida.ToString.Trim.ToUpper %></Concluida>)
            Retorno.<ClsTarefa>.First.Add(<Descricao><%= strDescricao.Trim %></Descricao>)
            Retorno.<ClsTarefa>.First.Add(<Inicio><%= strInicio.Trim %></Inicio>)
            Retorno.<ClsTarefa>.First.Add(<Fim><%= strFim.Trim %></Fim>)
            Return Retorno

        Catch Ex As Exception
            Throw Ex
        End Try
    End Function

    ''' <summary>
    ''' Cria o objeto apartir de um xml
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub sbMontaPorXml(p_xmlEntrada As XDocument)
        Try

            blnConcluida = IIf(p_xmlEntrada.<ClsTarefa>.<Concluida>.Value.Trim.ToUpper = "TRUE", True, False)
            strDescricao = p_xmlEntrada.<ClsTarefa>.<Descricao>.Value
            strInicio = p_xmlEntrada.<ClsTarefa>.<Inicio>.Value
            strFim = p_xmlEntrada.<ClsTarefa>.<Fim>.Value

        Catch Ex As Exception
            Throw Ex
        End Try
    End Sub

    ''' <summary>
    ''' Cria um clone do objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Clone() As clsTarefa
        Try

            Return New clsTarefa(fnToXml)

        Catch Ex As Exception
            Throw Ex
        End Try
    End Function




#End Region

#Region "Propriedades"
    ''' <summary>
    ''' Se a Tarefa foi concluida
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Concluida() As Boolean
        Get
            Return blnConcluida
        End Get
        Set(ByVal p_blnConcluida As Boolean)
            blnConcluida = p_blnConcluida
        End Set
    End Property

    ''' <summary>
    ''' Descricao da Tarefa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Descricao() As String
        Get
            Return strDescricao
        End Get
        Set(ByVal p_strDescricao As String)
            strDescricao = p_strDescricao
        End Set
    End Property

    ''' <summary>
    ''' Data Hora do inicio da Tarefa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Inicio() As String
        Get
            Return strInicio
        End Get
        Set(ByVal p_strInicio As String)
            strInicio = p_strInicio
        End Set
    End Property

    ''' <summary>
    ''' Data Hora do Fim da Tarefa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Fim() As String
        Get
            Return strFim
        End Get
        Set(ByVal p_strFim As String)
            strFim = p_strFim
        End Set
    End Property

#End Region

End Class
