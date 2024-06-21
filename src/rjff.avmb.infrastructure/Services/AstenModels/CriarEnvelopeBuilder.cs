using System.Linq;

using rjff.avmb.core.InputModels;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
    public class CriarEnvelopeBuilder
    {
        private CriarEnvelope _criarEnvelope;
        public CriarEnvelopeBuilder()
        {
            _criarEnvelope = new CriarEnvelope();
        }
        public CriarEnvelopeBuilder ComToken(string token)
        {
            _criarEnvelope.token = token;
            return this;
        }
        public CriarEnvelopeBuilder ComEnvelope(Envelope envelope)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            _criarEnvelope.@params.Envelope = envelope;
            return this;
        }
        public CriarEnvelopeBuilder ComGerarTags(string gerarTags)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(gerarTags))
                _criarEnvelope.@params.gerarTags = gerarTags;
            else
                _criarEnvelope.@params.gerarTags = "S";

            return this;
        }
        public CriarEnvelopeBuilder ComEncaminharImediatamente(string encaminharImediatamente)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(encaminharImediatamente))
                _criarEnvelope.@params.encaminharImediatamente = encaminharImediatamente;
            else
                _criarEnvelope.@params.encaminharImediatamente = "N";

            return this;
        }
        public CriarEnvelopeBuilder ComDetectarCampos(string detectarCampos)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(detectarCampos))
                _criarEnvelope.@params.detectarCampos = detectarCampos;
            else
                _criarEnvelope.@params.detectarCampos = "N";

            return this;
        }
        public CriarEnvelopeBuilder ComVerificarDuplicidadeConteudo(string verificarDuplicidadeConteudo)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(verificarDuplicidadeConteudo))
                _criarEnvelope.@params.verificarDuplicidadeConteudo = verificarDuplicidadeConteudo;
            else
                _criarEnvelope.@params.verificarDuplicidadeConteudo = "N";

            return this;
        }
        public CriarEnvelopeBuilder ComProcessarImagensEmSegundoPlano(string processarImagensEmSegundoPlano)
        {
            if (_criarEnvelope.@params == null)
                _criarEnvelope.@params = new ParamsCriarEnvelope();

            if (!string.IsNullOrEmpty(processarImagensEmSegundoPlano))
                _criarEnvelope.@params.processarImagensEmSegundoPlano = processarImagensEmSegundoPlano;
            else
                _criarEnvelope.@params.processarImagensEmSegundoPlano = "N";

            return this;
        }
        public CriarEnvelope Build()
        {
            return _criarEnvelope;
        }
    }

    public class EnvelopeBuilder
    {
        private Envelope envelope;

        public EnvelopeBuilder()
        {
            envelope = new Envelope();
        }

        public EnvelopeBuilder ComDescricao(string descricao)
        {
            envelope.descricao = descricao;
            return this;
        }
        public EnvelopeBuilder ComRepositorio(RepositorioInputModel repositorio)
        {
            envelope.Repositorio = new Repositorio()
            {
                id = repositorio.id
            };

            return this;
        }
        public EnvelopeBuilder ComMensagem(string? mensagem)
        {
            if (string.IsNullOrEmpty(mensagem))
                envelope.mensagem = null;
            else
                envelope.mensagem = mensagem;

            return this;
        }
        public EnvelopeBuilder ComListaDocumentos(ListadocumentosInputModel documentos)
        {
            if (envelope.listaDocumentos == null)
                envelope.listaDocumentos = new Listadocumentos();

            if (documentos != null && documentos.Documento != null)
            {
                envelope.listaDocumentos.Documento = new List<Documento>();

                foreach (var documentoInput in documentos.Documento)
                {
                    var documento = new Documento
                    {
                        conteudo = documentoInput.conteudo,
                        mimeType = documentoInput.mimeType,
                        nomeArquivo = documentoInput.nomeArquivo,
                        listaXMLAuxiliar = new Listaxmlauxiliar
                        {
                            XMLAuxiliar = documentoInput.listaXMLAuxiliar?.XMLAuxiliar?.Select(x1 => new Xmlauxiliar
                            {
                                conteudoXML = x1.conteudoXML,
                                nomeArquivo = x1.nomeArquivo,
                                listaXMLSignatario = new Listaxmlsignatario
                                {
                                    XMLSignatario = x1.listaXMLSignatario?.Select(t1 => new Xmlsignatario
                                    {
                                        carimboInterno = t1.XMLSignatario.Select(x => x.carimboInterno).FirstOrDefault(),
                                        cpfCnpjAceito = t1.XMLSignatario.Select(x => x.cpfCnpjAceito).FirstOrDefault(),
                                        emailSignatario = t1.XMLSignatario.Select(x => x.emailSignatario).FirstOrDefault(),
                                        idNodeAssinatura = t1.XMLSignatario.Select(x => x.idNodeAssinatura).FirstOrDefault(),
                                        restringirPessoaFisica = t1.XMLSignatario.Select(x => x.restringirPessoaFisica).FirstOrDefault(),
                                        restringirPessoaJuridica = t1.XMLSignatario.Select(x => x.restringirPessoaJuridica).FirstOrDefault(),
                                        restringirTiposCertificados = t1.XMLSignatario.Select(x => x.restringirTiposCertificados).FirstOrDefault()
                                    }).ToList()
                                }
                            }).ToList()
                        }
                    };

                    envelope.listaDocumentos.Documento.Add(documento);
                }
            }

            return this;
        }
        public EnvelopeBuilder ComListaSignatarios(ListasignatariosenvelopeInputModel signatarios)
        {
            if (envelope.listaSignatariosEnvelope == null)
                envelope.listaSignatariosEnvelope = new Listasignatariosenvelope();

            envelope.listaSignatariosEnvelope.SignatarioEnvelope = signatarios.SignatarioEnvelope;
            return this;
        }
        public EnvelopeBuilder ComListaObservadores(ListaobservadoresInputModel observadores)
        {
            if (envelope.listaObservadores == null)
                envelope.listaObservadores = new Listaobservadores();

            envelope.listaObservadores.Observador = observadores.Observador;
            return this;
        }
        public EnvelopeBuilder ComListaTags(ListatagsInputModel tags)
        {
            if (envelope.listaTags == null)
                envelope.listaTags = new Listatags();

            envelope.listaTags.Tag = tags.Tag;
            return this;
        }

        public EnvelopeBuilder ComListaInfoAdicional(ListainfoadicionalInputModel infoAdicional)
        {
            if (envelope.listaInfoAdicional == null)
                envelope.listaInfoAdicional = new Listainfoadicional();

            envelope.listaInfoAdicional.InfoAdicional = infoAdicional.InfoAdicional;
            return this;
        }

        public Envelope Build()
        {
            return envelope;
        }
    }





}
