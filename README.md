aspnet-approve_freight_api
================

.Net Core Web Api to approve freight
```
The software to be implemented will be an api restful built in .NET Core 3.1 WebAPI in C # language and will be consumed by an application in Flutter. 
In it, we will consult at 2 different banks. One to approve freight and the other to approve freight quotations.
The details of the project can be found in the documentation in the annex.
```

EndPoints:
------------

Type  | EndPoint
------------- | -------------
GET           | /v1/home/get-totals
GET           | /v1/company/ 
GET           | /v1/company-unit/	
GET           | /v1/channel/
GET           | /v1/carrier/
GET           | /v1/protocol/get-red-channels
GET           | /v1/protocol/get-unsuccessful-collection 
GET           | /v1/protocol/get-expensive-shipping 
GET           | /v1/protocol/get-ocurrences 
GET           | /v1/protocol/get-ocurrences-revalidation  


Project Structure:
------------            		
```
approvefreight_api
└── Controllers
	└── HomeController.cs
	└── ProtocolController.cs
	└── CompanyControllers.cs
	└── CompanyUniitControllers.cs
	└── CarrierController.cs
	└── ChannelController.cs
└── Models
	└── approvefreightAPIModel.cs
	└── TMSWORKANA
		└── Alcada_aprovacao.cs
		└── Aprovacao_alcada.cs
		└── Canal_venda.cs
		└── Empresa.cs
		└── Evento_erp.cs
		└── Localidade.cs
		└── Motivo_ocorrencia_padrao.cs
		└── Nivel_servico.cs
		└── Ocorrencia_transporte.cs
		└── Prazo_entrega.cs
		└── Protocolo.cs
		└── Protocolo_cotacao.cs
		└── Romaneio.cs
		└── Transportadora.cs
		└── Unidade_empresa.cs
		└── Usuario.cs
		└── TMSWORKANAContext.cs
└── appsetting.json
└── Program.cs
└── Startup.cs
```

Development Env:
------------
[Visiual Studio 2019](https://visualstudio.microsoft.com/downloads/)

Development Language:
------------
ASP.NET Core 3.1