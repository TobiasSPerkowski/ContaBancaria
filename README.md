# Sistema Bancário em C#

Projeto desenvolvido para o Programa AceleraMaker. 

O sistema simula operações bancárias utilizando conceitos de POO em C#, incluindo herança, polimorfismo, encapsulamento e persistência de dados.


## Requisitos

- .NET 8.0 SDK


## Como executar

Clone o repositório:
```bash
git clone https://github.com/TobiasSPerkowski/sistemaBancario.git
cd sistemaBancario/SistemaBancario.Console
dotnet run
```


## Funcionalidades

- Cadastro de contas
- Atualização de contas
- Remoção de contas
- Listagem de contas
- Busca por número da conta
- Depósito
- Saque
- Transferência
- Persistência em arquivo


## Estrutura

- Models
  - Classes das contas bancárias
- Repositories
  - Interface que define as operações do sistema
- Controllers
  - Implementação das operações e regras de negócio
- Data
  - Arquivos de persistência


## Melhorias futuras

- Persistência com banco de dados
- Sistema de autenticação
- Histórico de transações
- Aplicação de juros em poupança
- Interface gráfica


## Autor

Tobias Saueressig Perkowski