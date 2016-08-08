

''' <summary>
''' Classe clsPomodoroConfig
''' Autor: Kelvysb
''' Data: 03/08/2016
''' Finalidade: Classe de configuração do pomodoro desktop
''' Cliente: Kelvys
''' Tarefa: 0000
''' </summary>
''' <remarks></remarks>
Public Class clsPomodoroConfig

#Region "Declarações"
    Private intTempoPomodoro As Integer
    Private intQuantidadePomodoro As Integer
    Private intTempoIntervaloMenor As Integer
    Private intTempoIntervaloMaior As Integer
    Private intPosicaoTela As Integer
    Private blnSempreVisivel As Boolean
    Private blnAlertasonoro As Boolean
#End Region

#Region "Contrutores"
    Public Sub New()
        Try
            intTempoPomodoro = 25
            intQuantidadePomodoro = 4
            intTempoIntervaloMenor = 5
            intTempoIntervaloMaior = 30
            intPosicaoTela = 3
            blnSempreVisivel = True
            blnAlertasonoro = True
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

            Retorno = New XDocument(<ClsPomodoroConfig></ClsPomodoroConfig>)

            Retorno.<ClsPomodoroConfig>.First.Add(<TempoPomodoro><%= intTempoPomodoro %></TempoPomodoro>)
            Retorno.<ClsPomodoroConfig>.First.Add(<QuantidadePomodoro><%= intQuantidadePomodoro %></QuantidadePomodoro>)
            Retorno.<ClsPomodoroConfig>.First.Add(<TempoIntervaloMenor><%= intTempoIntervaloMenor %></TempoIntervaloMenor>)
            Retorno.<ClsPomodoroConfig>.First.Add(<TempoIntervaloMaior><%= intTempoIntervaloMaior %></TempoIntervaloMaior>)
            Retorno.<ClsPomodoroConfig>.First.Add(<PosicaoTela><%= intPosicaoTela %></PosicaoTela>)
            Retorno.<ClsPomodoroConfig>.First.Add(<SempreVisivel><%= blnSempreVisivel.ToString.Trim.ToUpper %></SempreVisivel>)
            Retorno.<ClsPomodoroConfig>.First.Add(<AlertaSonoro><%= blnAlertasonoro.ToString.Trim.ToUpper %></AlertaSonoro>)
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

            intTempoPomodoro = CInt(p_xmlEntrada.<ClsPomodoroConfig>.<TempoPomodoro>.Value)
            intQuantidadePomodoro = CInt(p_xmlEntrada.<ClsPomodoroConfig>.<QuantidadePomodoro>.Value)
            intTempoIntervaloMenor = CInt(p_xmlEntrada.<ClsPomodoroConfig>.<TempoIntervaloMenor>.Value)
            intTempoIntervaloMaior = CInt(p_xmlEntrada.<ClsPomodoroConfig>.<TempoIntervaloMaior>.Value)
            intPosicaoTela = CInt(p_xmlEntrada.<ClsPomodoroConfig>.<PosicaoTela>.Value)
            blnSempreVisivel = IIf(p_xmlEntrada.<ClsPomodoroConfig>.<SempreVisivel>.Value.Trim.ToUpper = "TRUE", True, False)
            blnAlertasonoro = IIf(p_xmlEntrada.<ClsPomodoroConfig>.<AlertaSonoro>.Value.Trim.ToUpper = "TRUE", True, False)

        Catch Ex As Exception
            Throw Ex
        End Try
    End Sub

    ''' <summary>
    ''' Cria um clone do objeto
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Clone() As clsPomodoroConfig
        Try

            Return New clsPomodoroConfig(fnToXml)

        Catch Ex As Exception
            Throw Ex
        End Try
    End Function



#End Region

#Region "Propriedades"
    ''' <summary>
    ''' Tempo em minutos de cada pomodoro
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TempoPomodoro() As Integer
        Get
            Return intTempoPomodoro
        End Get
        Set(ByVal p_intTempoPomodoro As Integer)
            intTempoPomodoro = p_intTempoPomodoro
        End Set
    End Property

    ''' <summary>
    ''' Quantidades de pomodoros antes do intervalo maior
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property QuantidadePomodoro() As Integer
        Get
            Return intQuantidadePomodoro
        End Get
        Set(ByVal p_intQuantidadePomodoro As Integer)
            intQuantidadePomodoro = p_intQuantidadePomodoro
        End Set
    End Property

    ''' <summary>
    ''' Tempo do intervalo menor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TempoIntervaloMenor() As Integer
        Get
            Return intTempoIntervaloMenor
        End Get
        Set(ByVal p_intTempoIntervaloMenor As Integer)
            intTempoIntervaloMenor = p_intTempoIntervaloMenor
        End Set
    End Property

    ''' <summary>
    ''' Tempo do intervalo menor
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TempoIntervaloMaior() As Integer
        Get
            Return intTempoIntervaloMaior
        End Get
        Set(ByVal p_intTempoIntervaloMaior As Integer)
            intTempoIntervaloMaior = p_intTempoIntervaloMaior
        End Set
    End Property

    ''' <summary>
    ''' Posicao na tela
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PosicaoTela() As Integer
        Get
            Return intPosicaoTela
        End Get
        Set(ByVal p_intPosicaoTela As Integer)
            intPosicaoTela = p_intPosicaoTela
        End Set
    End Property

    ''' <summary>
    ''' Se e sempre visível
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SempreVisivel() As Boolean
        Get
            Return blnSempreVisivel
        End Get
        Set(ByVal p_blnSempreVisivel As Boolean)
            blnSempreVisivel = p_blnSempreVisivel
        End Set
    End Property

    ''' <summary>
    ''' Se toca um alerta sonoro
    ''' </summary>
    ''' <returns></returns>
    Public Property AlertaSonoro() As Boolean
        Get
            Return blnAlertasonoro
        End Get
        Set(ByVal value As Boolean)
            blnAlertasonoro = value
        End Set
    End Property
#End Region

End Class
