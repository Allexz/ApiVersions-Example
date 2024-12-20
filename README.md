﻿# **Versionamento de Apis**

 ### **Descrição:**  
 Para este projeto foram utilizados os seguintes PACKAGES:
 1. Asp.Versioning.Http - VERSÃO 8.1.0
 2. Asp.Versioning.Mvc - VERSÃO 8.1.0
 3. Asp.Versioning.Mvc.ApiExplorer - VERSÃO 8.1.0
 4. Swashbuckle.AspNetCore - VERSÃO 7.1.0

### **Detalhamento do código:**
_Extratos_ da classe PROGRAM
```
//Comando utilizado para indicar a configuracao de versionamento de APIS
builder.Services.AddApiVersioning(options =>
{
    //Define a versao padrao caso o usuario nao opte por nenhuma
    options.DefaultApiVersion = new ApiVersion(1, 0);

    //Indica que se nenhuma versao for definida, a versao padrao sera assumida
    options.AssumeDefaultVersionWhenUnspecified = true;

    //Inclui as versoes suportadas no cabecalho da resposta HTTP
    options.ReportApiVersions = true;

    //Indica que a versao utilizada e indicada no segmento da URL
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

//Aqui e repetido o trecho acima e acrescentado metodo para configurar como as versoes da API serao expostas e documentadas
builder.Services.AddApiVersioning().AddApiExplorer(options =>
{
    //Define o formato do nome do grupo para as versoes da API, os 3 caracteres (VVV) serao substituidos pelo numero da versao
    options.GroupNameFormat = "'v'VVV";
    //Define que a versao da API deve ser incluida na URL das requisicoes
    options.SubstituteApiVersionInUrl = true;
});

//Adicionado o servico da geracao da documentacao via SWAGGER
builder.Services.AddSwaggerGen(options =>
{
    //Instancia de IApiVersionDescriptionProvider para fornecer informacoes disponiveis sobre a versoes da API
    var apiVersionProvider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

    //Percorre todas as descricoes das versoes da API disponiveis e monta cabecalho da interface SWAGGER
    foreach (var description in apiVersionProvider.ApiVersionDescriptions)
    {
        options.SwaggerDoc(description.GroupName, new OpenApiInfo
        {
            Title = $"API VERSÃO -  {description.ApiVersion}",
            Version = description.ApiVersion.ToString(),
            Description = $"Documentação da API - Versão {description.ApiVersion}"
        });
    }
});****

//Obtem uma instancia do mesmo objeto citado acima e percorre as versoes existentes na aplicacao configurando um ENDPOINT para cada uma destas versoes.
app.UseSwaggerUI(options =>
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});
```
