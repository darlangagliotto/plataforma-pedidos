# 📚 Curso: Plataforma de Pedidos – Arquitetura Moderna com .NET e React

Este documento é o **sumário oficial do curso**, servindo como fonte de verdade para garantir continuidade, coerência e evolução progressiva sem perdas de contexto.

---

## 🎯 Objetivo Final do Curso

Construir uma **Plataforma de Pedidos** moderna, escalável e alinhada ao mercado, utilizando:

* Arquitetura de **microserviços**
* Backend em **.NET 10 / C#**
* Frontend em **React + TypeScript**
* Comunicação síncrona e assíncrona
* Boas práticas reais de mercado

---

## 🧱 Fundamentos do Curso

* Curso guiado por **aulas sequenciais**
* Cada aula é **completa e fechada** (não depende de partes futuras)
* Código sempre **100% funcional**
* Caminhos completos dos arquivos
* Explicações **conceituais + práticas**

---

## 📦 Tecnologias Principais

### Backend

* .NET 10
* C#
* ASP.NET Core Web API
* Entity Framework Core
* Banco de dados InMemory (com evolução futura)
* Swagger / OpenAPI
* JWT (em aulas futuras)
* Webhooks
* Redis (cache e comunicação)
* RabbitMQ (eventos – aulas futuras)

### Frontend (fases posteriores)

* React
* TypeScript
* Arquitetura de componentes
* Testes com Playwright + Gherkin

### Infra / DevOps

* Docker
* Docker Compose
* CI/CD (conceitual e prático)

---

## 🧩 Serviços da Plataforma

### 🛂 AuthService

Responsável por:

* Autenticação
* Autorização
* Recebimento de eventos (webhooks)
* Evolução para JWT, validações e segurança

### 📦 OrderService

Responsável por:

* Criação de pedidos
* Persistência de dados
* Publicação de eventos
* Regras de negócio de pedidos

> Outros serviços poderão surgir conforme evolução do curso.

---

## 📘 Estrutura das Aulas

### ✅ Aula 1 – Fundação da Plataforma

* Criação do repositório
* Estrutura inicial de microserviços
* Criação do AuthService
* Controllers básicos
* Swagger configurado

📌 **Status**: Concluída e congelada

---

### ✅ Aula 2 – OrderService + Comunicação via Webhook

* Criação do OrderService
* Controller de pedidos
* DTOs iniciais
* Comunicação entre serviços via HTTP (Webhook)
* Simulação via Swagger
* Debug de SSL, HTTP/HTTPS e ambiente

📌 **Status**: Concluída e congelada

---

### ▶️ Aula 3 – Persistência, EF Core, DI e Estrutura Profissional

* Introdução ao Entity Framework Core
* Banco de dados InMemory
* Injeção de Dependência
* Separação Controller / Service / Repository
* Persistência real de pedidos
* Preparação para troca de banco futuramente

📌 **Status**: Próxima aula

---

### ⏭️ Aula 4 – Docker e Padronização de Ambiente

* Dockerfile por serviço
* Build e run com Docker
* Variáveis de ambiente
* Boas práticas de containers

---

### ⏭️ Aula 5 – Webhooks Realistas e Contratos

* Conceito de eventos de domínio
* Contratos de webhook
* Retry e tratamento de falhas
* Evolução do AuthService como consumidor de eventos

---

### ⏭️ Aula 6 – Redis

* Introdução ao Redis
* Cache de dados
* Uso prático no OrderService
* Estratégias de invalidação

---

### ⏭️ Aula 7 – Segurança e Autenticação

* JWT
* AuthService como emissor de tokens
* Proteção de endpoints

---

### ⏭️ Aula 8 – Mensageria (RabbitMQ)

* Eventos assíncronos
* Publicação e consumo
* Comparação Webhook vs Mensageria

---

⏭️ Aula 9 – Frontend React + TypeScript (base real)
Objetivo

Criar um frontend de verdade, pronto para mercado, consumindo seu backend.

Conteúdo

Setup React + TypeScript

Estrutura de pastas profissional

Serviços de API (Axios / Fetch)

Configuração de ambiente

Tipagem dos contratos

Página de criação de pedido

Página de listagem de pedidos

📌 Aqui o aluno vê o pedido nascer e aparecer na tela

⏭️ Aula 10 – Integração Frontend ↔ Backend

Objetivo: conectar o frontend real ao backend real

Conteúdo:

Fluxo completo de pedidos (end-to-end)

Consumo das APIs reais (Auth e Order)

Configuração de variáveis de ambiente no Vite

Login real com JWT

Interceptor de requisições

Token no localStorage

Proteção de rotas (PrivateRoute)

Tratamento de erros (401, 403, 500)

UX básico de loading e erro

📌 Resultado:

Usuário faz login → cria pedido → visualiza pedidos prontos
Tudo rodando via Docker Compose

⏭️ Aula 11 – Autenticação End-to-End

Objetivo: consolidar segurança no fluxo completo

Conteúdo:

Revisão do JWT no backend

Claims e roles

Middleware de autorização

Frontend respeitando permissões

Expiração de token

Logout

Refresh token (conceito + simulação simples)

Erros de autenticação no frontend

📌 Resultado:

Sistema fechado, seguro e coerente de ponta a ponta

⏭️ Aula 12 – Testes no Backend

Objetivo: garantir qualidade sem quebrar arquitetura

Conteúdo:

Testes de integração com .NET

WebApplicationFactory

Banco em memória

Testes de API (Auth e Order)

Estratégias de validação

Testando endpoints protegidos (JWT)

Testando publicação de eventos (RabbitMQ – mockado)

📌 Resultado:

Backend confiável e testável, padrão mercado

⏭️ Aula 13 – Testes Automatizados de UI (Playwright)

Objetivo: testar o sistema como o usuário usa

Conteúdo:

Conceito de testes E2E

Playwright + TypeScript

Setup do projeto

Teste de login

Teste de criação de pedido

Teste de listagem de pedidos

Execução local e via Docker

Boas práticas (selectors, fixtures)

📌 Resultado:

Testes rodando contra o sistema real

⏭️ Aula 14 – Integração Fullstack (Consolidação)

Objetivo: fechar todas as pontas

Conteúdo:

Revisão da arquitetura completa

Fluxo real: Front → API → Evento → Consumer

Observabilidade básica (logs)

Pontos de melhoria

Trade-offs arquiteturais

O que isso ensina para o mercado

📌 Resultado:

Visão clara de sistema real em produção

⏭️ Aula 15 – CI/CD e Infra Moderna

Objetivo: visão profissional de entrega

Conteúdo:

Conceitos de CI/CD

Pipeline com GitHub Actions

Build automático

Testes automáticos no pipeline

Build de imagens Docker

Conceito de deploy (cloud / k8s – teórico)

Boas práticas reais de mercado

📌 Resultado:

Projeto com cara de produto profissional