using rjff.avmb.core.InputModels;

namespace rjff.avmb.infrastructure.Services.AstenModels
{
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

            if (signatarios == null) return this;

            envelope.listaSignatariosEnvelope.SignatarioEnvelope = signatarios.SignatarioEnvelope;
            return this;
        }
        public EnvelopeBuilder ComListaObservadores(ListaobservadoresInputModel observadores)
        {
            if (envelope.listaObservadores == null)
                envelope.listaObservadores = new Listaobservadores();

            if (observadores == null) return this;

            envelope.listaObservadores.Observador = observadores.Observador;
            return this;
        }
        public EnvelopeBuilder ComListaTags(ListatagsInputModel tags)
        {
            if (envelope.listaTags == null)
                envelope.listaTags = new Listatags();

            if (tags == null) return this;

            envelope.listaTags.Tag = tags.Tag;
            return this;
        }

        public EnvelopeBuilder ComListaInfoAdicional(ListainfoadicionalInputModel infoAdicional)
        {
            if (envelope.listaInfoAdicional == null)
                envelope.listaInfoAdicional = new Listainfoadicional();

            if (infoAdicional == null) return this;

            envelope.listaInfoAdicional.InfoAdicional = infoAdicional.InfoAdicional;
            return this;
        }

        public Envelope Build()
        {
            return envelope;
        }
    }





}
