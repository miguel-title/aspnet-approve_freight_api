using System;
using System.Collections.Generic;

namespace approvefreight_api
{
    /*
    Get Response Header 
     */
    public class ResponseHeader
    {
        public string RequestStatus { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public string LanguageCode { get; set; }
    }

    /*
     Get Totals
     */
    public class getTotal
    {
        public int totalRedChannels { get; set; }
        public int totalOcurrences { get; set; }
        public int totalUnsuccessfulCollection { get; set; }
        public int totalProtocolsWeight { get; set; }
        public int totalExpensivesShipping { get; set; }
        public int totalRevalidations { get; set; }
    }

    public class getTotalResponse
    {
        public ResponseHeader Header { get; set; }
        public getTotal data { get; set; }
    }

    /*
     Get Company
     */
    public class company
    {
        public string nom_fantasia { get; set; }
        public int cod_empresa { get; set; }
    }

    public class companyResponse
    {
        public ResponseHeader Header { get; set; }
        public List<company> data { get; set; }
    }

    /*
     Get Company Unit
     */

    public class companyUnit
    {
        public string nom_unidade_empresa { get; set; }
        public int cod_unidade_empresa{ get; set; }
    }

    public class companyUnitResponse
    {
        public ResponseHeader Header { get; set; }
        public List<companyUnit> data { get; set; }
    }

    /*
     Get Channel
     */

    public class channel
    {
        public string dsc_canal_venda{ get; set; }
        public int cod_canal_venda{ get; set; }
    }

    public class channelResponse
    {
        public ResponseHeader Header { get; set; }
        public List<channel> data { get; set; }
    }

    /*
     Get Carrier
     */

    public class carrier
    {
        public int cod_transportadora { get; set; }
        public string nom_fantasia { get; set; }
    }

    public class carrierResponse
    {
        public ResponseHeader Header { get; set; }
        public List<carrier> data { get; set; }
    }

    /*
     Get Protocol_red_channel in Protocol
     */

    public class protocol_redchannel
    {
        public string dsc_nivel_servico{ get; set; }
        public int cod_protocolo { get; set; }
        public string nom_fantasia { get; set; }
        public string val_frete { get; set; }
        public string dsc_justificativa_canal_vermelho{ get; set; }
        public string alcada{ get; set; }
        public int qtd_dia_prazo { get; set; }
    }

    public class protocol_redchannel_response
    {
        public ResponseHeader Header { get; set; }
        public List<protocol_redchannel> data { get; set; }
    }

    /*
     Get Protocol_unsuccessful_collection
     */

    public class protocol_unsuccessful_collection
    {
        public int cod_protocolo { get; set; }
        public string cliente { get; set; }
        public string nom_fantasia { get; set; }
        public string dat_saida { get; set; }
        public string dat_limite_entrega { get; set; }
        public string valor { get; set; }
        public string notas { get; set; }
        public string valor_acao { get; set; }
        public string alcada { get; set; }
    }

    public class protocol_unsuccessful_collection_response
    {
        public ResponseHeader Header { get; set; }
        public List<protocol_unsuccessful_collection> data { get; set; }
    }

    /*
     Get Protocol_expensive_shipping
     */

    public class protocol_expensive_shipping
    {
        public string dsc_nivel_servico { get; set; }
        public int cod_protocolo { get; set; }
        public string nom_fantasia { get; set; }
        public string val_frete { get; set; }
        public string alcada { get; set; }
        public int qtd_dia_prazo { get; set; }
        public int cod_romaneio { get; set; }
    }

    public class protocol_expensive_shipping_response
    {
        public ResponseHeader Header { get; set; }
        public List<protocol_expensive_shipping> data { get; set; }
    }

    /*
     Get Occurences in Protocol
     */

    public class protocol_ocurrences
    {
        public int cod_protocolo { get; set; }
        public string cliente { get; set; }
        public string dsc_motivo_ocorrencia_padrao { get; set; }
        public string nom_fantasia { get; set; }
        public DateTime dat_saida { get; set; }
        public DateTime dat_limite_entrega { get; set; }
        public string valor { get; set; }
        public string notas { get; set; }
        public string validaao_acao_transportadora { get; set; }
        public string nom_usuario { get; set; }
        public string sgl_unidade_federacao { get; set; }
    }

    public class protocol_ocurrences_response
    {
        public ResponseHeader Header { get; set; }
        public List<protocol_ocurrences> data { get; set; }
    }

    /*
     Get Weight in Protocol
     */

    public class protocol_weight
    {
        public int cod_protocolo { get; set; }
        public string notas { get; set; }
        public string produtos { get; set; }
        public int qtd_peso_total { get; set; }
        public string valor { get; set; }
    }

    public class protocol_weight_response
    {
        public ResponseHeader Header { get; set; }
        public List<protocol_weight> data { get; set; }
    }

    /*
     Get Ocurrences_revalidation in Protocol
     */
    public class protocol_ocurrences_revalidation
    {
        public int cod_protocolo { get; set; }
        public string cliente { get; set; }
        public string dsc_motivo_ocorrencia_padrao { get; set; }
        public string nom_fantasia { get; set; }
        public DateTime dat_saida { get; set; }
        public DateTime dat_limite_entrega { get; set; }
        public string valor { get; set; }
        public string notas { get; set; }
        public string validaao_acao_transportadora { get; set; }
        public string valor_acao { get; set; }
    }

    public class protocol_ocurrences_revalidation_response
    {
        public ResponseHeader Header { get; set; }
        public List<protocol_ocurrences_revalidation> data { get; set; }
    }

    //Get Token
    public class LoginTokenVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class ResponseTokenVM
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string token_type { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
