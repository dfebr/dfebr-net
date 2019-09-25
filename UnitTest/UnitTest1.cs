// ==================================================================
// DFeBR - Documentos Fiscais Eletrônicos em .Net
// Projeto: UnitTest
// Autores: 
// Valnei Filho  e-mail: vmarinpietri@yahoo.com.br por DSBR Brasil Tecnologia www.DSBRBRASIL.com.br;
// Marco Polo  e-mail: marcopoloviana@hotmail.com 
// Data Criação:21/05/2019
// Todos os direitos reservados
// ===================================================================


#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using DFeBR.EmissorNFe;
using DFeBR.EmissorNFe.Builders;
using DFeBR.EmissorNFe.Danfe.Entidades;
using DFeBR.EmissorNFe.Danfe.Interfaces;
using DFeBR.EmissorNFe.Danfe.NFCe;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Configurar;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.Informacoes.Emitente;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Autorizacao;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Evento;
using DFeBR.EmissorNFe.Dominio.NotaFiscalEletronica.RetornoServicos.Status;
using DFeBR.EmissorNFe.Servicos.VersaoNFe4;
using DFeBR.EmissorNFe.Utilidade;
using DFeBR.EmissorNFe.Utilidade.Tipos;
using Xunit;

#endregion

namespace UnitTest
{
    public class UnitTest1
    {
        /// <summary>
        ///     Obter dados de configuração
        /// </summary>
        /// <returns></returns>
        private EmissorServicoConfig ObterConfiguracao()
        {
            var serial = "‎1B1200E4B990B6C5844F6486D891792C";
            var senha = "1234";
            var c1 = new EmissorServicoConfig(VersaoServico.Ve400, Estado.Ba, TipoAmbiente.Homologacao);
            c1.ConfiguraCSC("000001", "5F241960-80CB-4837-9945-61490D173CBA");
            c1.ConfiguraEmitente("32806205000155", "", "Nome", "Fantasia", "155731233", "", "", "", CRT.SimplesNacional, "logradouro", "1",
                    "", "Bairro", 2927408, "Municipio", "BA", "41620500", null);
            c1.ConfiguraSchemaXSD(true, $@"{Environment.CurrentDirectory}\Schemas\versao4.00");
            c1.ConfiguraArquivoRetorno(true, @"D:\");
            c1.ConfiguraCertificadoA1Repositorio(serial);
            //Segurança para nao transmitir em produção
            if (c1.Ambiente == TipoAmbiente.Producao) throw new Exception("Testes em produção não permitido.");
            return c1;

            //var serial = "‎1A81F7AE101714929D230EC688A4BA7F";
            //var senha = "1234";
            //var c1 = new EmissorServicoConfig(VersaoServico.Ve400, Estado.Ba, TipoAmbiente.Homologacao);
            //c1.ConfiguraCSC("000001", "58C851CA-C1C7-413C-BBDB-3EC38CF5F39F");
            //c1.ConfiguraEmitente("13712048000174", "", "Nome", "Fantasia", "018738210", "", "", "", CRT.SimplesNacional, "logradouro", "1",
            //        "", "Bairro", 41620500, "Municipio", "BA", "41620500", null);
            //c1.ConfiguraSchemaXSD(true, $@"{Environment.CurrentDirectory}\Entidades\Schemas\versao4.00");
            //c1.ConfiguraArquivoRetorno(true, @"D:\");
            //c1.ConfiguraCertificadoA1Repositorio(serial);
            //return c1;
        }

        [Fact]
        [Description("Consultar status do serviço")]
        public void ConsultarStatusServico()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var result = servNfe.ConsultarStatus();
            //Código de status com sucesso 
            Assert.Equal(107, result.Retorno.cStat);
        }

        [Fact]
        [Description("Consultar uma NFCe pela chave")]
        public void ConsultarUmaNfCeUsandoChave()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var chave = "NFe29190417784038000103650980000000011000000014";
            var retorno = servNfe.ConsultarPelaChave(chave, true, "65");
            Assert.NotNull(retorno);
        }

        [Fact]
        [Description("Consultar uma NFCe pela chave")]
        public void ConsultarUmaNfCeUsandoStringXml()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            //var xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><nfeProc xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"3.10\"><NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"3.10\" Id=\"NFe29190417784038000103650980000000011000000014\"><ide><cUF>35</cUF><cNF>33397018</cNF><natOp>VENDA DE PRODUCAO</natOp><indPag>2</indPag><mod>55</mod><serie>1</serie><nNF>671</nNF><dhEmi>2016-08-24T14:59:57-02:00</dhEmi><dhSaiEnt>2016-08-25T15:00:00-02:00</dhSaiEnt><tpNF>1</tpNF><idDest>2</idDest><cMunFG>3552809</cMunFG><tpImp>1</tpImp><tpEmis>1</tpEmis><cDV>2</cDV><tpAmb>1</tpAmb><finNFe>1</finNFe><indFinal>1</indFinal><indPres>0</indPres><procEmi>0</procEmi><verProc>BIKES SPORTS BICICLE</verProc></ide><emit><CNPJ>24104582000114</CNPJ><xNome>BIKES SPORTS BICICLETAS e ACESSORIOS EIRELI</xNome><xFant>BIKES SPORTS BICICLETAS e ACESSORIOS EIRELI</xFant><enderEmit><xLgr>RUA SEBASTIAO DE SOUZA SILVA</xLgr><nro>175</nro><xBairro>PARQUE LAGUNA</xBairro><cMun>3552809</cMun><xMun>TABOAO DA SERRA</xMun><UF>SP</UF><CEP>06775970</CEP><fone>1199999999</fone></enderEmit><IE>675268326118</IE><CRT>3</CRT></emit><dest><CNPJ>17784038000103</CNPJ><xNome>ANAILTO SILVA DE OLIVEIRA</xNome><enderDest><xLgr>RUA EURICO DA COSTA COUTINHO</xLgr><nro>100</nro><xBairro>MUSSURUNGA I</xBairro><cMun>2927408</cMun><xMun>SALVADOR</xMun><UF>BA</UF><CEP>41490050</CEP><cPais>1058</cPais><xPais>BRASIL</xPais><fone>7132524235</fone></enderDest><indIEDest>1</indIEDest><IE>107728249</IE><email>duchabikes@hotmail.com</email></dest><det nItem=\"1\"><prod><cProd>000000000009679</cProd><cEAN /><xProd>BIC 16 POCOLOCA BRANCA CACESS LILAS</xProd><NCM>87120010</NCM><CFOP>6101</CFOP><uCom>PC</uCom><qCom>1.0000</qCom><vUnCom>126.1400</vUnCom><vProd>126.14</vProd><cEANTrib /><uTrib>PC</uTrib><qTrib>1.0000</qTrib><vUnTrib>126.1400</vUnTrib><indTot>1</indTot></prod><imposto><ICMS><ICMS00><orig>0</orig><CST>00</CST><modBC>0</modBC><vBC>126.14</vBC><pICMS>7.00</pICMS><vICMS>8.83</vICMS></ICMS00></ICMS><IPI><cEnq>999</cEnq><IPITrib><CST>50</CST><vBC>126.14</vBC><pIPI>10.00</pIPI><vIPI>12.61</vIPI></IPITrib></IPI><PIS><PISAliq><CST>01</CST><vBC>126.14</vBC><pPIS>0.65</pPIS><vPIS>0.82</vPIS></PISAliq></PIS><COFINS><COFINSAliq><CST>01</CST><vBC>126.14</vBC><pCOFINS>3.00</pCOFINS><vCOFINS>3.78</vCOFINS></COFINSAliq></COFINS></imposto></det><det nItem=\"2\"><prod><cProd>000000000009681</cProd><cEAN /><xProd>BIC 16 POCOLOCA PRETA CACESS PINK</xProd><NCM>87120010</NCM><CFOP>6101</CFOP><uCom>PC</uCom><qCom>2.0000</qCom><vUnCom>126.1400</vUnCom><vProd>252.28</vProd><cEANTrib /><uTrib>PC</uTrib><qTrib>2.0000</qTrib><vUnTrib>126.1400</vUnTrib><indTot>1</indTot></prod><imposto><ICMS><ICMS00><orig>0</orig><CST>00</CST><modBC>0</modBC><vBC>252.28</vBC><pICMS>7.00</pICMS><vICMS>17.66</vICMS></ICMS00></ICMS><IPI><cEnq>999</cEnq><IPITrib><CST>50</CST><vBC>252.28</vBC><pIPI>10.00</pIPI><vIPI>25.23</vIPI></IPITrib></IPI><PIS><PISAliq><CST>01</CST><vBC>252.28</vBC><pPIS>0.65</pPIS><vPIS>1.64</vPIS></PISAliq></PIS><COFINS><COFINSAliq><CST>01</CST><vBC>252.28</vBC><pCOFINS>3.00</pCOFINS><vCOFINS>7.57</vCOFINS></COFINSAliq></COFINS></imposto></det><det nItem=\"3\"><prod><cProd>000000000009680</cProd><cEAN /><xProd>BIC 16 POCOLOCA ROSA C ACESS PINK</xProd><NCM>87120010</NCM><CFOP>6101</CFOP><uCom>PC</uCom><qCom>3.0000</qCom><vUnCom>126.1400</vUnCom><vProd>378.42</vProd><cEANTrib /><uTrib>PC</uTrib><qTrib>3.0000</qTrib><vUnTrib>126.1400</vUnTrib><indTot>1</indTot></prod><imposto><ICMS><ICMS00><orig>0</orig><CST>00</CST><modBC>0</modBC><vBC>378.42</vBC><pICMS>7.00</pICMS><vICMS>26.49</vICMS></ICMS00></ICMS><IPI><cEnq>999</cEnq><IPITrib><CST>50</CST><vBC>378.42</vBC><pIPI>10.00</pIPI><vIPI>37.84</vIPI></IPITrib></IPI><PIS><PISAliq><CST>01</CST><vBC>378.42</vBC><pPIS>0.65</pPIS><vPIS>2.46</vPIS></PISAliq></PIS><COFINS><COFINSAliq><CST>01</CST><vBC>378.42</vBC><pCOFINS>3.00</pCOFINS><vCOFINS>11.35</vCOFINS></COFINSAliq></COFINS></imposto></det><det nItem=\"4\"><prod><cProd>000000000009682</cProd><cEAN /><xProd>BIC 16 POCOLOCO AZUL CACESS VERMELHO</xProd><NCM>87120010</NCM><CFOP>6101</CFOP><uCom>PC</uCom><qCom>2.0000</qCom><vUnCom>126.1400</vUnCom><vProd>252.28</vProd><cEANTrib /><uTrib>PC</uTrib><qTrib>2.0000</qTrib><vUnTrib>126.1400</vUnTrib><indTot>1</indTot></prod><imposto><ICMS><ICMS00><orig>0</orig><CST>00</CST><modBC>0</modBC><vBC>252.28</vBC><pICMS>7.00</pICMS><vICMS>17.66</vICMS></ICMS00></ICMS><IPI><cEnq>999</cEnq><IPITrib><CST>50</CST><vBC>252.28</vBC><pIPI>10.00</pIPI><vIPI>25.23</vIPI></IPITrib></IPI><PIS><PISAliq><CST>01</CST><vBC>252.28</vBC><pPIS>0.65</pPIS><vPIS>1.64</vPIS></PISAliq></PIS><COFINS><COFINSAliq><CST>01</CST><vBC>252.28</vBC><pCOFINS>3.00</pCOFINS><vCOFINS>7.57</vCOFINS></COFINSAliq></COFINS></imposto></det><det nItem=\"5\"><prod><cProd>000000000009683</cProd><cEAN /><xProd>BIC 16 POCOLOCO PRETO CACESS VERDE</xProd><NCM>87120010</NCM><CFOP>6101</CFOP><uCom>PC</uCom><qCom>3.0000</qCom><vUnCom>126.1400</vUnCom><vProd>378.42</vProd><cEANTrib /><uTrib>PC</uTrib><qTrib>3.0000</qTrib><vUnTrib>126.1400</vUnTrib><indTot>1</indTot></prod><imposto><ICMS><ICMS00><orig>0</orig><CST>00</CST><modBC>0</modBC><vBC>378.42</vBC><pICMS>7.00</pICMS><vICMS>26.49</vICMS></ICMS00></ICMS><IPI><cEnq>999</cEnq><IPITrib><CST>50</CST><vBC>378.42</vBC><pIPI>10.00</pIPI><vIPI>37.84</vIPI></IPITrib></IPI><PIS><PISAliq><CST>01</CST><vBC>378.42</vBC><pPIS>0.65</pPIS><vPIS>2.46</vPIS></PISAliq></PIS><COFINS><COFINSAliq><CST>01</CST><vBC>378.42</vBC><pCOFINS>3.00</pCOFINS><vCOFINS>11.35</vCOFINS></COFINSAliq></COFINS></imposto></det><total><ICMSTot><vBC>1387.54</vBC><vICMS>97.13</vICMS><vICMSDeson>0.00</vICMSDeson><vBCST>0.00</vBCST><vST>0.00</vST><vProd>1387.54</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>138.75</vIPI><vPIS>9.02</vPIS><vCOFINS>41.62</vCOFINS><vOutro>0.00</vOutro><vNF>1526.29</vNF></ICMSTot></total><transp><modFrete>0</modFrete><transporta><CNPJ>22792561000103</CNPJ><xNome>TRANSMADRUGA  FRETE POR CONTA DO REMETENTE</xNome><IE>746011172114</IE><xEnder>RUA AGOSTINHO DE COLI</xEnder><xMun>ESTIVA GERBI</xMun><UF>SP</UF></transporta><veicTransp><placa>PNI9999</placa><UF>SP</UF></veicTransp><vol><qVol>11</qVol><esp>CAIXAS</esp><pesoB>53.900</pesoB></vol></transp><cobr><fat><nFat>000671</nFat><vOrig>1526.29</vOrig><vLiq>1526.29</vLiq></fat><dup><nDup>000671A</nDup><dVenc>2016-09-03</dVenc><vDup>1526.29</vDup></dup></cobr><infAdic><infCpl>Valor Aprox dos Tributos R$   49743  3585% Fonte IBPT   Em caso de apresentar defeitos, acionar a assistencia tecnica atraves do TEL 1938617977, eou email sac@smetalurgicacombr REDESPACHO TRANSMARINHO TRANSPORTES  FRETE P CONTA DO DESTINATARIO  AVENIDA PAPA JOAO PAULO I No 2258      VILA AEROPORTO    GUARULHOS    SP  CNPJ19440740000410  IE796194703113  CEP07170350</infCpl></infAdic></infNFe><Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\"><SignedInfo><CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\" /><SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\" /><Reference URI=\"#NFe35160824104582000114550010000006711333970182\"><Transforms><Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\" /><Transform Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\" /></Transforms><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\" /><DigestValue>J8js17sajM78C99ILo+Q30WDxoA=</DigestValue></Reference></SignedInfo><SignatureValue>Y42SPUCvRSopC9esdRSynt/ua24pkGezrWbG4U4upnKWx3sPFencePqK2K/0bQkIIwEqlM5u2V/GSBrt5w5vk1NVhOjjkKJQsoBqzZEeska8E8ktUiHLAjcFMyrE86OdPl8y49rVoh2gQf3fspzmgph+PrRpP55XiRV5RD04UTRoKvU1vzL6TcBzpYssGQ+ycLSgrUmLprQBxl6cgAeNjhJlZjFInTLJ2H99idkL7uJiMlmQqiFdINhRQ5HV4LPpLAVFE/DJS4s2ujhjONQsnumvSsuByo+49kjPkXgy1PoUhYnS9pvekPpzX0TxO/7FyZRQ4eKIeTYJRDESU4V3zQ==</SignatureValue><KeyInfo><X509Data><X509Certificate>MIIIWzCCBkOgAwIBAgIQT+7jkOGrPFDTLuhnAXSPuzANBgkqhkiG9w0BAQsFADB4MQswCQYDVQQGEwJCUjETMBEGA1UEChMKSUNQLUJyYXNpbDE2MDQGA1UECxMtU2VjcmV0YXJpYSBkYSBSZWNlaXRhIEZlZGVyYWwgZG8gQnJhc2lsIC0gUkZCMRwwGgYDVQQDExNBQyBDZXJ0aXNpZ24gUkZCIEc0MB4XDTE2MDIxMjAwMDAwMFoXDTE3MDIxMDIzNTk1OVowggEEMQswCQYDVQQGEwJCUjETMBEGA1UEChQKSUNQLUJyYXNpbDELMAkGA1UECBMCU1AxGDAWBgNVBAcUD1RBQk9BTyBEQSBTRVJSQTE2MDQGA1UECxQtU2VjcmV0YXJpYSBkYSBSZWNlaXRhIEZlZGVyYWwgZG8gQnJhc2lsIC0gUkZCMRYwFAYDVQQLFA1SRkIgZS1DTlBKIEExMSQwIgYDVQQLFBtBdXRlbnRpY2FkbyBwb3IgQVIgT0RMRVZBVEkxQzBBBgNVBAMTOkJJS0VTIFNQT1JUUyBCSUNJQ0xFVEFTIEUgQUNFU1NPUklPUyBFSVJFTEk6MjQxMDQ1ODIwMDAxMTQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDCakh7sftKkck2y0k88cU+C9YcsdimLYegGk5/aAG0aqVYyB4FbNIaFbGnNDqBMVDbWxQqNFlYjzwNcOUOjh5IQys42+8ayrbOKIR/zbYE4JDEPD4kghlZDt4Z5htSBT12VL4VNVhaNQOeC5UJdbFESaBnHQcXXugTsA/4Nr7XOeZaWBi1Ae3LmDvhkoZklP03kLF4Urf9Rchz31Bm2TrkgPEVnfoSVgSRYaQyVfV0p+ROJFx3eP6M2h02JEGLLDJCaxcTfDtO96F6Zdxuv5EDf9IVMAAqtHySIuxlLW8G8wsBHcIOce/9soAs4BFNHuh6aAPFU0saeGY6cH62p3pFAgMBAAGjggNRMIIDTTCBtgYDVR0RBIGuMIGroD0GBWBMAQMEoDQEMjE4MDQxOTM1MDMwODY2NDc4NzYwMDAwMDAwMDAwMDAwMDAwMDAxNDM1MzUyNlNTUFNQoB0GBWBMAQMCoBQEElpJTERBIEJPUkdFUyBBTFZFU6AZBgVgTAEDA6AQBA4yNDEwNDU4MjAwMDExNKAXBgVgTAEDB6AOBAwwMDAwMDAwMDAwMDCBF2RpZWdvQHBsYW5lZmlzY28uY29tLmJyMAkGA1UdEwQCMAAwHwYDVR0jBBgwFoAULpHq1m3lslmC3DiFKXY0FlY80D4wDgYDVR0PAQH/BAQDAgXgMH8GA1UdIAR4MHYwdAYGYEwBAgEMMGowaAYIKwYBBQUHAgEWXGh0dHA6Ly9pY3AtYnJhc2lsLmNlcnRpc2lnbi5jb20uYnIvcmVwb3NpdG9yaW8vZHBjL0FDX0NlcnRpc2lnbl9SRkIvRFBDX0FDX0NlcnRpc2lnbl9SRkIucGRmMIIBFgYDVR0fBIIBDTCCAQkwV6BVoFOGUWh0dHA6Ly9pY3AtYnJhc2lsLmNlcnRpc2lnbi5jb20uYnIvcmVwb3NpdG9yaW8vbGNyL0FDQ2VydGlzaWduUkZCRzQvTGF0ZXN0Q1JMLmNybDBWoFSgUoZQaHR0cDovL2ljcC1icmFzaWwub3V0cmFsY3IuY29tLmJyL3JlcG9zaXRvcmlvL2xjci9BQ0NlcnRpc2lnblJGQkc0L0xhdGVzdENSTC5jcmwwVqBUoFKGUGh0dHA6Ly9yZXBvc2l0b3Jpby5pY3BicmFzaWwuZ292LmJyL2xjci9DZXJ0aXNpZ24vQUNDZXJ0aXNpZ25SRkJHNC9MYXRlc3RDUkwuY3JsMB0GA1UdJQQWMBQGCCsGAQUFBwMCBggrBgEFBQcDBDCBmwYIKwYBBQUHAQEEgY4wgYswXwYIKwYBBQUHMAKGU2h0dHA6Ly9pY3AtYnJhc2lsLmNlcnRpc2lnbi5jb20uYnIvcmVwb3NpdG9yaW8vY2VydGlmaWNhZG9zL0FDX0NlcnRpc2lnbl9SRkJfRzQucDdjMCgGCCsGAQUFBzABhhxodHRwOi8vb2NzcC5jZXJ0aXNpZ24uY29tLmJyMA0GCSqGSIb3DQEBCwUAA4ICAQBXx7YWXok8LkDcAUotqT1RPm4hSMcIcalt5eQ2y2YUznKAgeFMbm6eL/0bfFRP1s6oaRzzimPNrhSWSkdhm4tPuc37e8kL9e4xrVdoWY7ZrzPq1pmqYkHtDl0jLMFlqa2Ag9Jt1cen+Cx4C75uLcNnnDgdPqbKAHuhBpaS0zdYJHWdTOMKP7Y5tZM4JCVL6O0Zpk1+lapsAjTFKE7M3C4ZNRsk4wjCNDmI8zAmZWBTXpuE0UjTqqDdi0dlXTLEHevkSlBw4V5dxGZrp230BfQLaqTlf4QJ5W5QDCTSe1GYMWoJQnPWqpBFaIS20ZdHHy/H0hOKpEUftpbqReS1B4530lqCrQINcLcChtTj2o6ggtF/R+i/nuuAwcy1KuEaTxNZOCZk87Cr5kidgIqq5lA3Yuw4b7KQW7d7KJV86oOI+unvPfPQvYiuduoVs8gz+moDVYKtBgqZ+WeY7X4RppzhoumI8+V1W2cE9WILn63xXG0a3Y9XjfWxBtc5kj4wKD3frgurpWECYJXpcJ8YoUVuWzTD38rsQd6i9X/2gD7rLAVfCwfOXBp7F/u4FaOjYMYNJ1gxz0K8LR5uVqt/XUqdJxyuB62bN0BrWTO9yxTd2aaBcS4kIr716zyvxpeYbtxIjtlkYKFwlWtwfwJmVP9uSuD7Gxwd7s8Axdac5J7CjA==</X509Certificate></X509Data></KeyInfo></Signature></NFe><protNFe versao=\"3.10\" xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infProt><tpAmb>1</tpAmb><verAplic>SP_NFE_PL_008i2</verAplic><chNFe>35160824104582000114550010000006711333970182</chNFe><dhRecbto>2016-08-24T15:00:34-03:00</dhRecbto><nProt>135160523776426</nProt><digVal>J8js17sajM78C99ILo+Q30WDxoA=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso da NF-e</xMotivo></infProt></protNFe></nfeProc>";
            var xml = Utils.LerArquivo("Arquivos", "NFCe.xml");
            var retorno = servNfe.ConsultarPelaChave(xml, false, "65");
            Assert.NotNull(retorno);
        }

        [Fact]
        [Description("Inutilizar um numero de nota fiscal")]
        public void InutilizarUmNumeroDeNotaFDiscal()
        {
            //Descomentar para executar rotina
            //Esta rotina não deve ser executada automaticamente
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var retorno = servNfe.Inutilizar("1778403800-0103", 19, "65", 1, 1, 3, "Ipsum lorem Lorem Ipsum reflect hujlenb");
            Assert.NotNull(retorno);
        }

        [Fact]
        [Description("Obter dados de endereço do arquivo Json")]
        public void ObterDadosEnderecadorJson()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            Assert.NotNull(config.EmissorConfig.ConfigServ.UrlsNFe);
        }

        [Fact]
        [Description("Verificar criação da DANFE Emissão Normal")]
        public void ObterDanfe()
        {
            var c1 = ObterConfiguracao();
            var cabecalho = new CabecalhoNFCe("Empresa DSBR BRasil", "32806205000155", "155731233", "10", "Rua Itacimirim loja 22",
                    "São Paulo", "SP", "40620500");
            var dest = new DestinatarioNFCe("", "", "");
            var pagamento = new PagamentoNFCe(120, 120, 120, 0.5,
                    new List<FormPagNFCe> {new FormPagNFCe("Dinheiro", 120), new FormPagNFCe("Cartão Crédito", 23.56)});
            var produtos = new List<ProdutoNFCe>();
            for (var i = 0; i < 11; i++) produtos.Add(new ProdutoNFCe(i.ToString(), $"Produto {i}", "UND", i, i * 2, i * 3));
            var impostos = new ImpostosNFCe(5, 6, 7);
            var infAdc = new InfAdicNFCe("Informação");
            var urlConsulta = c1.ConfigServ.UrlsNFce.Homologacao.QrcodeConsulta;
            var corpo = new CorpoNFCe(false, "00000", Status.Autorizada, produtos, true, pagamento, impostos, infAdc, "1", DateTime.Now,
                    urlConsulta, "29190417784038000103650980000000011000000014", dest);
            var urlQrcode =
                    "http://hnfe.sefaz.ba.gov.br/servicos/nfce/modulos/geral/NFCEC_consulta_chave_acesso.aspx?p=29190517784038000103650980000000011000000026|2|2|1|b72d0c7a8a2d5bd267287215216be079669162a7";
            var rodape = new RodapeNFCe("5512006230010", urlQrcode, "Emissor Fiscal DSBR Brasil - www.dsbrbrasil.com.br");
            IDanfeHtml d1 = new DanfeNFCeHtml(TipoPapelNFCe.Mm80, cabecalho, corpo, rodape);
            var doc = d1.ObterDocHtml();
            Utils.EscreverArquivo("D:\\", "NFce", doc.Html);
        }

        [Fact]
        [Description("Transmitir uma Nota Fiscal NFCe")]
        public void TransmitirNotaFiscal()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var retorno = servNfe.Autorizar(1, new List<NFeBuilder>());
            Assert.NotNull(retorno);
        }


        [Fact]
        [Description("Transmitir uma Nota Fiscal NFCe compactada usando uma string XMl")]
        public void TransmitirNotaFiscalCompactadoUsandoUmaStringXml()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var xml =
                    "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"4.00\"><ide><cUF>29</cUF><cNF>2</cNF><natOp>Venda de mercadoria adquirida ou recebida de terceiros</natOp><mod>65</mod><serie>98</serie><nNF>1</nNF><dhEmi>" +
                    DateTime.Now +
                    "</dhEmi><tpNF>1</tpNF><idDest>1</idDest><cMunFG>2927408</cMunFG><tpImp>4</tpImp><tpEmis>1</tpEmis><cDV>0</cDV><tpAmb>2</tpAmb><finNFe>1</finNFe><indFinal>1</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>Test 1.0</verProc></ide><emit><CNPJ>17784038000103</CNPJ><xNome>BIKETOP COMER. E SERV. DE BICICLETAS EIRELI</xNome><xFant>PLANETA BIKE</xFant><enderEmit><xLgr>Rua Virgildasio Sena</xLgr><nro>215</nro><xBairro>Boca do Rio</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>41710220</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderEmit><IE>107728249</IE><IM>00000000000000</IM><CRT>1</CRT></emit><det nItem=\"1\"><prod><cProd>1656</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>87120010</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>123.0000000000</vUnCom><vProd>123.00</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>123.0000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>13.41</vTotTrib><ICMS><ICMSSN900><orig>5</orig><CSOSN>900</CSOSN></ICMSSN900></ICMS></imposto><infAdProd>Trib aprox R$: 13,41 Federal, 0,00 Estadual e 0,000000 Municipal. Fonte: IBPT 801EC4.</infAdProd></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0.00</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>123.00</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vOutro>0.00</vOutro><vNF>123.00</vNF><vTotTrib>13.41</vTotTrib></ICMSTot></total><transp><modFrete>9</modFrete></transp><pag><detPag><tPag>01</tPag><vPag>123.00</vPag></detPag></pag><infAdic><infCpl>Trib aprox R$: 13,41 Federal, 0,00 Estadual e Municipal: 0,00 Fonte: IBPT 801EC4</infCpl></infAdic></infNFe></NFe>";
            var retorno = servNfe.Autorizar(xml, true);
        }

        [Fact]
        [Description("Transmitir uma Nota Fiscal NFCe usando uma string XMl")]
        public void TransmitirNotaFiscalComsumidorUsandoUmaStringXml()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var xml =
                    "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"4.00\"><ide><cUF>29</cUF><cNF>8561</cNF><natOp>Venda de mercadoria adquirida ou recebida de terceiros</natOp><mod>65</mod><serie>1</serie><nNF>224</nNF><dhEmi>" +
                    DateTime.Now +
                    "</dhEmi><tpNF>1</tpNF><idDest>1</idDest><cMunFG>2927408</cMunFG><tpImp>4</tpImp><tpEmis>1</tpEmis><cDV>0</cDV><tpAmb>2</tpAmb><finNFe>1</finNFe><indFinal>1</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>Test 1.0</verProc></ide><emit><CNPJ>32806205000155</CNPJ><xNome>BIKETOP COMER. E SERV. DE BICICLETAS EIRELI</xNome><xFant>PLANETA BIKE</xFant><enderEmit><xLgr>Rua Virgildasio Sena</xLgr><nro>215</nro><xBairro>Boca do Rio</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>41710220</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderEmit><IE>155731233</IE><IM>00000000000000</IM><CRT>1</CRT></emit><det nItem=\"1\"><prod><cProd>1656</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>87120010</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>123.0000000000</vUnCom><vProd>123.00</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>123.0000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>13.41</vTotTrib><ICMS><ICMSSN900><orig>5</orig><CSOSN>900</CSOSN></ICMSSN900></ICMS></imposto><infAdProd>Trib aprox R$: 13,41 Federal, 0,00 Estadual e 0,000000 Municipal. Fonte: IBPT 801EC4.</infAdProd></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0.00</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>123.00</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vOutro>0.00</vOutro><vNF>123.00</vNF><vTotTrib>13.41</vTotTrib></ICMSTot></total><transp><modFrete>9</modFrete></transp><pag><detPag><tPag>01</tPag><vPag>123.00</vPag></detPag></pag><infAdic><infCpl>Trib aprox R$: 13,41 Federal, 0,00 Estadual e Municipal: 0,00 Fonte: IBPT 801EC4</infCpl></infAdic></infNFe></NFe>";
            var retorno = servNfe.Autorizar(xml);
            Assert.NotNull(retorno);
        }


        [Fact]
        [Description("Transmitir uma Nota Fiscal para Cancelamento")]
        public void TransmitirNotaFiscalEletronicaCancelamento()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var xml =
                    "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"4.00\"><ide><cUF>29</cUF><cNF>252</cNF><natOp>Venda de mercadoria adquirida ou recebida de terceiros</natOp><mod>65</mod><serie>1</serie><nNF>6798</nNF><dhEmi>" +
                    DateTime.Now +
                    "</dhEmi><tpNF>1</tpNF><idDest>1</idDest><cMunFG>2927408</cMunFG><tpImp>4</tpImp><tpEmis>1</tpEmis><cDV>0</cDV><tpAmb>2</tpAmb><finNFe>1</finNFe><indFinal>1</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>Test 1.0</verProc></ide><emit><CNPJ>32806205000155</CNPJ><xNome>BIKETOP COMER. E SERV. DE BICICLETAS EIRELI</xNome><xFant>PLANETA BIKE</xFant><enderEmit><xLgr>Rua Virgildasio Sena</xLgr><nro>215</nro><xBairro>Boca do Rio</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>41710220</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderEmit><IE>155731233</IE><IM>00000000000000</IM><CRT>1</CRT></emit><det nItem=\"1\"><prod><cProd>1656</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>87120010</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>123.0000000000</vUnCom><vProd>123.00</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>123.0000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>13.41</vTotTrib><ICMS><ICMSSN900><orig>5</orig><CSOSN>900</CSOSN></ICMSSN900></ICMS></imposto><infAdProd>Trib aprox R$: 13,41 Federal, 0,00 Estadual e 0,000000 Municipal. Fonte: IBPT 801EC4.</infAdProd></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0.00</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>123.00</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vOutro>0.00</vOutro><vNF>123.00</vNF><vTotTrib>13.41</vTotTrib></ICMSTot></total><transp><modFrete>9</modFrete></transp><pag><detPag><tPag>01</tPag><vPag>123.00</vPag></detPag></pag><infAdic><infCpl>Trib aprox R$: 13,41 Federal, 0,00 Estadual e Municipal: 0,00 Fonte: IBPT 801EC4</infCpl></infAdic></infNFe></NFe>";
            // var retorno = servNfe.Autorizar(xml);
            //var status = retorno.Retorno.cStat;
            //if (status == 104)
            //{
            var protocolo = "329190000118543";
            var chave = "29190532806205000155650010000002231000001227";
            var canc = servNfe.CancelarNFe(1,
                    new List<EventoBuilder>
                    {
                            new EventoBuilder(1, protocolo, chave, "Motivo de Teste Motivo de Teste",
                                    config.EmissorConfig.Emitente.CNPJ)
                    }, "65");
            var ret2 = canc.Retorno;
            Assert.NotNull(ret2);
            //}
        }

        [Fact]
        [Description("Transmitir uma Nota Fiscal NFe 55 usando uma string XMl, testando situações de contingência")]
        public void TransmitirNotaFiscalEletronicaUsandoUmaStringXmlTesteContigencia()
        {
            //para testar essa unidade é necessário induzir uma exception de timeout ou erro http 500 em [ServHttpSoapBase.ObterResposta]
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var tpEmissao = "4"; //Se 4 entao o sistema deve obter a url de contingencia DPEC
            var xml =
                    "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"4.00\"><ide><cUF>29</cUF><cNF>15222</cNF><natOp>Devolucao de venda de mercadoria adquirida ou recebida de te</natOp><mod>55</mod><serie>1</serie><nNF>123</nNF><dhEmi>" +
                    DateTime.Now + "</dhEmi><tpNF>0</tpNF><idDest>1</idDest><cMunFG>2927408</cMunFG><tpImp>1</tpImp><tpEmis>" + tpEmissao +
                    "</tpEmis><cDV>0</cDV><tpAmb>2</tpAmb><finNFe>1</finNFe><indFinal>0</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>4.00</verProc></ide><emit><CNPJ>32806205000155</CNPJ><xNome>YYYYYYYYYYYY</xNome><xFant>YYYYYYYYYYYY</xFant><enderEmit><xLgr>Rua Virgildasio Sena</xLgr><nro>215</nro><xBairro>Boca do Rio</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>41710220</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderEmit><IE>155731233</IE><IM>00000000000000</IM><CRT>1</CRT></emit><dest><CPF>94782024568</CPF><xNome>NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xNome><enderDest><xLgr>TRAVESSA SR DO BONFIM N 218</xLgr><nro>218</nro><xCpl>2o ANDAR</xCpl><xBairro>ENGOMADEIRA</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>48000000</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderDest><indIEDest>9</indIEDest></dest><det nItem=\"1\"><prod><cProd>1860</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>87149500</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>65.9000000000</vUnCom><vProd>65.90</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>65.9000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>7.18</vTotTrib><ICMS><ICMSSN102><orig>2</orig><CSOSN>102</CSOSN></ICMSSN102></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>53</CST></IPINT></IPI><PIS><PISOutr><CST>99</CST><vBC>65.90</vBC><pPIS>0.4300</pPIS><vPIS>0.28</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>99</CST><vBC>65.90</vBC><pCOFINS>1.9800</pCOFINS><vCOFINS>1.30</vCOFINS></COFINSOutr></COFINS></imposto><infAdProd>Trib aprox R$: 7,18 Federal, 0,00 Estadual e 0,000000 Municipal. Fonte: IBPT D11D7F.</infAdProd></det><det nItem=\"2\"><prod><cProd>2021</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>40132000</NCM><CEST>1600900</CEST><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>25.0000000000</vUnCom><vProd>25.00</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>25.0000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>8.96</vTotTrib><ICMS><ICMSSN102><orig>1</orig><CSOSN>102</CSOSN></ICMSSN102></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>53</CST></IPINT></IPI><PIS><PISOutr><CST>99</CST><vBC>25.00</vBC><pPIS>0.5000</pPIS><vPIS>0.13</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>99</CST><vBC>25.00</vBC><pCOFINS>2.3800</pCOFINS><vCOFINS>0.60</vCOFINS></COFINSOutr></COFINS></imposto><infAdProd>Trib aprox R$: 4,46 Federal, 4,50 Estadual e 0,000000 Municipal. Fonte: IBPT D11D7F.</infAdProd></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0.00</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>90.90</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vOutro>0.00</vOutro><vNF>90.90</vNF><vTotTrib>16.14</vTotTrib></ICMSTot></total><transp><modFrete>9</modFrete></transp><pag><detPag><tPag>90</tPag><vPag>90.90</vPag></detPag></pag><infAdic><infCpl>Documento emitido por ME ou EPP optante pelo Simples Nacional. Nao gera direito a credito fiscal de IPI.</infCpl></infAdic></infNFe></NFe>";
            var r1 = servNfe.Autorizar(xml);

            //Levantar uma exceção por conta do tipo de emissão ser numero 1, quando deveria ser 4,6 ou 7
            //Assert.Throws<ArgumentOutOfRangeException>(() => servNfe.Autorizar(xml));
        }


        [Fact]
        [Description("Transmitir uma Nota Fiscal NFe 55 usando uma string XMl, testando situações de contingência")]
        public void TransmitirNotaFiscalEletronicaUsandoUmaStringXmlTesteContigenciaDeveSerLancadoUmaException()
        {
            //para testar essa unidade é necessário induzir uma exception de timeout ou erro http 500 em [ServHttpSoapBase.ObterResposta]
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            var tpEmissao = "1";
            var xml =
                    "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"4.00\"><ide><cUF>29</cUF><cNF>15222</cNF><natOp>Devolucao de venda de mercadoria adquirida ou recebida de te</natOp><mod>55</mod><serie>1</serie><nNF>123</nNF><dhEmi>" +
                    DateTime.Now + "</dhEmi><tpNF>0</tpNF><idDest>1</idDest><cMunFG>2927408</cMunFG><tpImp>1</tpImp><tpEmis>" + tpEmissao +
                    "</tpEmis><cDV>0</cDV><tpAmb>2</tpAmb><finNFe>1</finNFe><indFinal>0</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>4.00</verProc></ide><emit><CNPJ>32806205000155</CNPJ><xNome>YYYYYYYYYYYY</xNome><xFant>YYYYYYYYYYYY</xFant><enderEmit><xLgr>Rua Virgildasio Sena</xLgr><nro>215</nro><xBairro>Boca do Rio</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>41710220</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderEmit><IE>155731233</IE><IM>00000000000000</IM><CRT>1</CRT></emit><dest><CPF>94782024568</CPF><xNome>NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xNome><enderDest><xLgr>TRAVESSA SR DO BONFIM N 218</xLgr><nro>218</nro><xCpl>2o ANDAR</xCpl><xBairro>ENGOMADEIRA</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>48000000</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderDest><indIEDest>9</indIEDest></dest><det nItem=\"1\"><prod><cProd>1860</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>87149500</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>65.9000000000</vUnCom><vProd>65.90</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>65.9000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>7.18</vTotTrib><ICMS><ICMSSN102><orig>2</orig><CSOSN>102</CSOSN></ICMSSN102></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>53</CST></IPINT></IPI><PIS><PISOutr><CST>99</CST><vBC>65.90</vBC><pPIS>0.4300</pPIS><vPIS>0.28</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>99</CST><vBC>65.90</vBC><pCOFINS>1.9800</pCOFINS><vCOFINS>1.30</vCOFINS></COFINSOutr></COFINS></imposto><infAdProd>Trib aprox R$: 7,18 Federal, 0,00 Estadual e 0,000000 Municipal. Fonte: IBPT D11D7F.</infAdProd></det><det nItem=\"2\"><prod><cProd>2021</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>40132000</NCM><CEST>1600900</CEST><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>25.0000000000</vUnCom><vProd>25.00</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>25.0000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>8.96</vTotTrib><ICMS><ICMSSN102><orig>1</orig><CSOSN>102</CSOSN></ICMSSN102></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>53</CST></IPINT></IPI><PIS><PISOutr><CST>99</CST><vBC>25.00</vBC><pPIS>0.5000</pPIS><vPIS>0.13</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>99</CST><vBC>25.00</vBC><pCOFINS>2.3800</pCOFINS><vCOFINS>0.60</vCOFINS></COFINSOutr></COFINS></imposto><infAdProd>Trib aprox R$: 4,46 Federal, 4,50 Estadual e 0,000000 Municipal. Fonte: IBPT D11D7F.</infAdProd></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0.00</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>90.90</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vOutro>0.00</vOutro><vNF>90.90</vNF><vTotTrib>16.14</vTotTrib></ICMSTot></total><transp><modFrete>9</modFrete></transp><pag><detPag><tPag>90</tPag><vPag>90.90</vPag></detPag></pag><infAdic><infCpl>Documento emitido por ME ou EPP optante pelo Simples Nacional. Nao gera direito a credito fiscal de IPI.</infCpl></infAdic></infNFe></NFe>";
            //Levantar uma exceção por conta do tipo de emissão ser numero 1, quando deveria ser 4,6 ou 7
            Assert.Throws<ArgumentOutOfRangeException>(() => servNfe.Autorizar(xml));
        }

        [Fact]
        [Description("Transmitir uma Nota Fiscal Modelo 55 de modo assincrono usando uma string XMl")]
        public void TransmitirNotaFiscalModelo55AssincronamenteUsandoUmaStringXml()
        {
            var c1 = ObterConfiguracao();
            var config = new Configurar(c1);
            var servNfe = new ServNFe4(config.EmissorConfig);
            //var xml = "<NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe versao=\"4.00\"><ide><cUF>29</cUF><cNF>15222</cNF><natOp>Devolucao de venda de mercadoria adquirida ou recebida de te</natOp><mod>55</mod><serie>1</serie><nNF>123</nNF><dhEmi>" + DateTime.Now + "</dhEmi><tpNF>0</tpNF><idDest>1</idDest><cMunFG>2927408</cMunFG><tpImp>1</tpImp><tpEmis>1</tpEmis><cDV>0</cDV><tpAmb>2</tpAmb><finNFe>1</finNFe><indFinal>0</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>4.00</verProc></ide><emit><CNPJ>32806205000155</CNPJ><xNome>YYYYYYYYYYYY</xNome><xFant>YYYYYYYYYYYY</xFant><enderEmit><xLgr>Rua Virgildasio Sena</xLgr><nro>215</nro><xBairro>Boca do Rio</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>41710220</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderEmit><IE>155731233</IE><IM>00000000000000</IM><CRT>1</CRT></emit><dest><CPF>94782024568</CPF><xNome>NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xNome><enderDest><xLgr>TRAVESSA SR DO BONFIM N 218</xLgr><nro>218</nro><xCpl>2o ANDAR</xCpl><xBairro>ENGOMADEIRA</xBairro><cMun>2927408</cMun><xMun>Salvador</xMun><UF>BA</UF><CEP>48000000</CEP><cPais>1058</cPais><xPais>Brasil</xPais></enderDest><indIEDest>9</indIEDest></dest><det nItem=\"1\"><prod><cProd>1860</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>87149500</NCM><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>65.9000000000</vUnCom><vProd>65.90</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>65.9000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>7.18</vTotTrib><ICMS><ICMSSN102><orig>2</orig><CSOSN>102</CSOSN></ICMSSN102></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>53</CST></IPINT></IPI><PIS><PISOutr><CST>99</CST><vBC>65.90</vBC><pPIS>0.4300</pPIS><vPIS>0.28</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>99</CST><vBC>65.90</vBC><pCOFINS>1.9800</pCOFINS><vCOFINS>1.30</vCOFINS></COFINSOutr></COFINS></imposto><infAdProd>Trib aprox R$: 7,18 Federal, 0,00 Estadual e 0,000000 Municipal. Fonte: IBPT D11D7F.</infAdProd></det><det nItem=\"2\"><prod><cProd>2021</cProd><cEAN>SEM GTIN</cEAN><xProd>NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xProd><NCM>40132000</NCM><CEST>1600900</CEST><CFOP>5102</CFOP><uCom>UN</uCom><qCom>1.0000</qCom><vUnCom>25.0000000000</vUnCom><vProd>25.00</vProd><cEANTrib>SEM GTIN</cEANTrib><uTrib>UN</uTrib><qTrib>1.0000</qTrib><vUnTrib>25.0000000000</vUnTrib><indTot>1</indTot></prod><imposto><vTotTrib>8.96</vTotTrib><ICMS><ICMSSN102><orig>1</orig><CSOSN>102</CSOSN></ICMSSN102></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>53</CST></IPINT></IPI><PIS><PISOutr><CST>99</CST><vBC>25.00</vBC><pPIS>0.5000</pPIS><vPIS>0.13</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>99</CST><vBC>25.00</vBC><pCOFINS>2.3800</pCOFINS><vCOFINS>0.60</vCOFINS></COFINSOutr></COFINS></imposto><infAdProd>Trib aprox R$: 4,46 Federal, 4,50 Estadual e 0,000000 Municipal. Fonte: IBPT D11D7F.</infAdProd></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0.00</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>90.90</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>0.00</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.00</vPIS><vCOFINS>0.00</vCOFINS><vOutro>0.00</vOutro><vNF>90.90</vNF><vTotTrib>16.14</vTotTrib></ICMSTot></total><transp><modFrete>9</modFrete></transp><pag><detPag><tPag>90</tPag><vPag>90.90</vPag></detPag></pag><infAdic><infCpl>Documento emitido por ME ou EPP optante pelo Simples Nacional. Nao gera direito a credito fiscal de IPI.</infCpl></infAdic></infNFe></NFe>";
            //var retorno = servNfe.Autorizar(xml);
            //var recibo = "291100010193770"; //retorno.Retorno.infRec.nRec;
            var recibo = "291100010197259";
            //Consultar pelo Recibo
            var retorno2 = servNfe.ConsultarPeloRecibo(recibo, "55");
        }


        [Fact]
        [Description("Obter dados de retorno do serviço")]
        public void TratamentoDadosRetornoServico()
        {
            var retorno =
                    "<?xml version=\"1.0\" encoding=\"utf -8\"?><retConsStatServ versao = \"1.07\" xmlns = \"http://www.portalfiscal.inf.br/nfe\">" +
                    "<tpAmb>2</tpAmb><verAplic>SVRS20100112141427</verAplic><cStat>107</cStat>" +
                    "<xMotivo>Servico em Operacao</xMotivo><cUF>33</cUF>" +
                    "<dhRecbto>2010 - 02 - 07T01: 04:19</dhRecbto><tMed>1</tMed></retConsStatServ>";
            var s1 = Utils.ObterValorNodeStringXml(retorno, "cStat");
            Assert.Equal("107", s1);
            var s2 = Utils.ObterValorNodeStringXml(retorno, "xMotivo");
            Assert.Equal("Servico em Operacao", s2);
            var s3 = Utils.ObterValorNodeStringXml(retorno, "cUF");
            Assert.Equal("33", s3);
            var s4 = Utils.ObterValorNodeStringXml(retorno, "dhRecbto");
            Assert.Equal("2010 - 02 - 07T01: 04:19", s4);
        }

        [Fact]
        [Description("Deserializar Xml RetEnviNFe")]
        public void TratarRetornoAutorizacao()
        {
            //Obter arquivo
            var retorno = Utils.LerArquivo("Arquivos", "RetEnvieNFe.xml");
            //Obter Node
            var node = Utils.ObterNodeDeStringXml("retEnviNFe", retorno);
            var retENviNFe = Utils.XmlStringParaClasse<retEnviNFe>(node);
            var count = retENviNFe.protNFe.infProt.Count;
            Assert.Equal(3, count);
        }

        [Fact]
        [Description("Deserializar XMl retConsStatServ")]
        public void TratarRetornoConsultaStatus()
        {
            //Obter arquivo
            var retorno = Utils.LerArquivo("Arquivos", "RetConsStatServ.xml");
            //Obter Node
            var node = Utils.ObterNodeDeStringXml("retConsStatServ", retorno);
            var retConsNFe = Utils.XmlStringParaClasse<retConsStatServ>(node);
            var codStatus = retConsNFe.cStat;
            Assert.Equal(107, codStatus);
        }
    }
}