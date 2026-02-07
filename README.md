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
Objetivo

Fechar o primeiro fluxo real da aplicação.

Conteúdo

Integração com OrderService

Tratamento de loading / erro

Validação de formulário

Fluxo completo:

UI → API → Banco → Cache → Evento


Observando efeitos colaterais (audit)

📌 Aqui a aplicação já funciona como produto

⏭️ Aula 11 – Autenticação End-to-End
Objetivo

Transformar o projeto em algo empregável.

Conteúdo

JWT no backend

Login / logout

Proteção de rotas no frontend

Interceptors de API

Claims e contexto do usuário

Fluxo autenticado completo

📌 Aqui o projeto deixa de ser “demo” e vira plataforma

⏭️ Aula 12 – Testes Automatizados (Backend + UI)

Agora sim, testes no momento certo.

Parte 1 – Testes de integração (Backend)

Testes de API com WebApplicationFactory

Banco em memória

Testes de fluxo real

Validação de status, payload, regras

Parte 2 – Testes de UI com Playwright ⭐

Setup Playwright

Teste de criação de pedido via UI

Teste de login

Teste end-to-end completo

Rodando local e em pipeline

📌 Aqui você testa:

“O usuário consegue criar um pedido do começo ao fim?”

⏭️ Aula 13 – Integração Fullstack (consolidação)
Objetivo

Organizar, limpar e consolidar tudo.

Revisão de arquitetura

Ajustes de contratos

Versionamento

Observabilidade básica

Logs úteis

Padrões finais

⏭️ Aula 14 – CI/CD e Infra Moderna

Agora sim faz sentido.

Conteúdo

Pipeline (build + test)

Build de backend

Build de frontend

Execução de testes Playwright no pipeline

Conceitos reais de mercado:

qualidade

confiança

deploy seguro