<h1 align="center">CRUD CLIENTES</h1>

<p align="center">
  <img alt="Made by Lucas Lira" src="https://img.shields.io/badge/made%20by-Lucas%20Lira-informational">
  
  <a href="license.md">
  <img alt="License" src="https://img.shields.io/badge/License-MIT-informational">
  </a>
</p>

___

<h3 align="center">
  <a href="#information_source-sobre">Sobre</a> |  
  <a href="#Tecnologias">Tecnologias</a> |
  <a href="#Padrão">Padrão de Projeto</a> |
  <a href="#licença">Licença</a>
</h3>

___

<br>

## :information_source: Sobre

Projeto desenvolvido com o objetivo de aplicar o conceito de CQRS em um CRUD.


<br>

## 🚀 Tecnologias

As seguintes ferramentas foram usadas na construção dos projetos:

- [Node.js](https://nodejs.org/en/)
- [Angular](https://angular.io/)
- [TypeScript](https://www.typescriptlang.org/)
- [.Net Core](https://docs.microsoft.com/pt-br/dotnet/core/introduction)
- [MediatR](https://github.com/jbogard/MediatR)

<br>

## Padrão
    <h3>BackEnd</h3>
      
      <p>Desenvolvido em 4 principais camadas:</p>
          <p>CURD_CQRS: Responsavel por receber todas as requisições http e enviar para seu respectivo fluxo.</p>
          <p>Domain: Responsavel pela definição de Models, interfaces, Commands entre outros.</p>
          <p>Infra.Data: Responsavel pela comunicação com nossa fonte de dados.</p>
          <p>Service: Responsavel pela regra de negocio.</p>
   
    <h3>FontEnd</>
    
      <p>Por se tratar de um CRUD de uma entidade apenas, a pagina de listagem de cliente abre assim que a aplicação é executada. Os conponentes de tela bem como a </p>
      <p>comunicação com a api encontrace na pasta app > customers</p>
        <p>create-customer: pagina de criação de clientes</p>
        <p>update-customer: pagina de atualização de clientes</p>
        <p>Models: Modelos de envio e retorno da api</p>
        <p>customers.component.ts: pagina de listagem de clientes</p>
        <p>customer.service.ts: classe responsavel pela comunicação com a API configurada com a url "https://localhost:5001/customer".</p>
      
<br>
## 📄 Licença 

Esse projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
