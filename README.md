# DFeBR.Net
**O que é o DFeBR.Net?**

É um framework para emissão e logística de documentos fiscais para a plataforma .NET.
Simples, eficiente, extensível e robusto, conta com as melhores abordagens em termos de design patterns para garantir ao desenvolvedor segurança e confiabilidade no funcionamento.

**A quem se destina?**

Desenvolvedores da plataforma .NET que atuam na área de automação comercial, sendo compatível com .NET Framework 4.x e .NET Core, através do .NET Standard 2.

**Tecnologias e evoluções**

O novo DFeBR.Net é a baseado no antigo **Zeus.DFe Framework**, criado por uma nova equipe de desenvolvedores extremamente capacitados para entregar a melhor solução possível em termos de tecnologia e arquitetura de software.
Dentre as várias evoluções feitas, a mais significativa é a total compatibilidade com .NET Core e .NET 4.x, alem de diversas mudanças internas que tornam o novo framework extremamente confiável para o desenvolvedor.
Incluímos também um novo conceito para construção dos objetos de documentos fiscais. Como é sabido que a estrutura de uma NFe é extensa e complexa, trabalhamos duro para simplificar o máximo possível a implementação e os resultados foram incríveis.

**Transição menos dolorosa entre as versões dos serviços**

A arquitetura do novo projeto facilita a transição ou migração de versões do serviços. Sempre que for implementada uma versão mais nova dos documentos fiscais, basta alterar a chamada das classes de construção do documento. 
Ex.:
 
```C#
  new DetalheNFe40(...); //construtor do detalhe da NFe 4.0
  new DetalheNFe50(...); //construtor do detalhe da NFe 5.0
```

**Exemplo simples de uso**

**Configuração do framework**

A configuração do framework é feita através da classe "EmissorServicoConfig". Nos pontos onde se vê **"..."** são parâmetros de métodos.
```C#
   private EmissorServicoConfig GetConfig()
   {
      var config = new EmissorServicoConfig(...);
      config.ConfiguraEmitente(...);
      config.ConfiguraCertificadoA1Repositorio("serial do certificado");
      config.ConfiguraCSC("CscID", "CscToken");
      config.ConfiguraArquivoRetorno(true, @"C:\XML\");

      return config;
  }
```

**Construindo os "pedaços" da nota fiscal**

Cada seção da nota fiscal é constituida por classes distintas, específicas da versão do serviço, que simplifica a confecção da estrutura
Ex.:

```C#
  private DetalheNFe40 GetDetalhe()
  {
      var detalhe = new DetalheNFe40(...); //dados basicos do produto
      detalhe.SetICMS20(...); //dados para o ICMS20
      detalhe.SetIPI(...); //dados para o IPI
      detalhe.SetPISOutr(...); //dados para PIS
      detalhe.SetII(...); //dados para II
      detalhe.SetCOFINSOutr(...); //dados para COFINS

      return detalhe;
  }
```

**Emitindo sua primeira NFe**

Segundo as dicas acima, você deve construir seus objetos para confecção da NFe e informá-los na classe "NFeBuilder", e por fim, submetê-la ao serviço de autorização

```C#

  private IServicoStrategy ObterServico()
  {
		return new ServNFe4(GetConfig());
  }

  public void EmitirNFeComBuilder()
  {
      NFeBuilder builder = new NFeBuilder(GetConfig());
      builder.SetIdentificacao(new IdentificacaoNFe40(...));
      builder.SetDestinatario(new DestinatarioNFe40(...));
      builder.AddDetalhe(GetDetalhe());
      builder.SetTotal(new TotalNFe40(.....));
      builder.SetTransporte(new TransporteNFe40());
      builder.SetCobranca(GetCobranca());
      builder.AddPagamento(GetPagamento());
      builder.SetResponsavel(new ResponsavelTecNFe40(....));

      var servNfe = ObterServico();
      IRetAutorz retorno = servNfe.Autorizar(builder.NFe);
  }
```
Caso prefira, você também pode manipular diretamente as classes originais que compõe a NFe e submetê-las ao serviço de autorização da mesma forma, porém a quantidade e complexidade do código vai ser consideravelmente maior.

**Principais mantenedores**


O novo projeto conta com uma equipe seleta de experientes desenvolvedores da plataforma .NET, pessoas com alta carga de conhecimento e extremamente capacitados para entregar a comunidade a melhor solução possível para facilitar o árduo trabalho de emissão de documentos fiscais. 

A equipe está organizada por áreas de projeto, cujo elas são: 

**“Core-Framework”** - Camada de mais baixo nível do projeto, responsável por de fato fazer todo o processo de transmissão de documentos e manipulação de XML’s 

**“Support-Layers”** - Camada de mais alto nível do projeto, responsável por interagir direta/indiretamente com o desenvolvedor-usuário, afim de garantir que todas as informações que chegarem no “Core-Framework” estejam devidamente tratadas e válidas. 

**“Code Revisor”** - Membros do projeto responsáveis pela revisão de código enviado pela comunidade a fim de contribuir com o projeto. 

**“Suporte Fiscal e Regras de Negócio”** - Membros do projeto responsáveis por estar antenados as legislações fiscais e orquestrar a correta implementação das evoluções mais recentes estabelecidas pelas Sefaz’es. 


Os membros são: 

**Eduardo Moreira    “Core-Framework”**

**Henrique Felipe    “Core-Framework”**

**Leo Vitor Sousa    “Support-Layers”**

**Marco P. Viana     “Suporte Fiscal e Regras de Negócio”**

**Paulo Cesar Filho  “Code Revisor, Core-Framework, Support-Layers "**

**Ricardo I.T.S.A    “Support-Layers”**

**Rodrigo Navas 	   “Core-Framework”**

**Valnei Batista	   “Core-Framework”**

**Vigo Marcelo	     “Support-Layers, Core-Framework"** 

**Marcos Vinícius    “Support-Layers”**

