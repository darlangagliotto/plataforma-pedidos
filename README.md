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

### ⏭️ Aula 9 – Testes no Backend

* Testes de integração
* Testes de API
* Estratégias de validação

---

### ⏭️ Aula 10 – Frontend React + TypeScript

* Consumo das APIs
* Estrutura moderna de frontend
* Integração com backend

---

### ⏭️ Aula 11 – Integração Fullstack

* Fluxo completo de pedidos
* Autenticação end-to-end

---

### ⏭️ Aula 12 – CI/CD e Infra Moderna

* Pipelines
* Build automatizado
* Conceitos reais de mercado
