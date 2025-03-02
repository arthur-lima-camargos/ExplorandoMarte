# 🚀 Explorando Marte

## 🌍 Sobre o Projeto

O projeto **Explorando Marte** simula a movimentação de sondas exploratórias enviadas a Marte. As sondas recebem comandos para navegar por um planalto retangular, girando para a esquerda (L), direita (R) e movendo-se para frente (M). O objetivo é processar corretamente os comandos e garantir que as sondas operem dentro dos limites do planalto e sem colisões.

## 🛠️ Configuração e Execução

### 🔧 Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download)
- Editor de código (VSCode, Visual Studio, etc.)
- Git (para versionamento)

### ▶️ Executando o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/ExplorandoMarte.git
   cd ExplorandoMarte
   ```
2. Compile e execute o projeto:
   ```bash
   dotnet build
   dotnet run --project .\ExplorandoMarte\
   ```

## 📐 Decisões de Projeto

O projeto segue os princípios **SOLID** e adota uma abordagem orientada a objetos. As principais decisões incluem:

- **Encapsulamento**: Classes como `Rover`, `Plateau` e `Position` separam responsabilidades.
- **Validação de limites**: A classe `Plateau` impede movimentações inválidas.
- **Prevenção de colisões**: O sistema impede que duas sondas ocupem a mesma posição.

## 🎨 Design Patterns Aplicados

### 🏭 **Factory Pattern** (Padrão de Fábrica)

Usado na classe `RoverFactory`, que cria instâncias de `Rover` a partir dos dados de entrada. Isso permite desacoplar a criação de objetos da lógica principal do programa.

### 🎮 **Command Pattern** (Padrão de Comando)

Cada comando (`L`, `R`, `M`) é encapsulado em uma classe (`MoveForwardCommand`, `RotateLeftCommand`, `RotateRightCommand`). Isso facilita a extensão do sistema e mantém o código modular.

### 💡 **Justificativa para Escolha de CLI e Arquivo de Texto**

A escolha de usar CLI e arquivo de texto foi baseada nos seguintes fatores:

- **Simplicidade**: É uma solução direta e alinhada ao exemplo clássico fornecido no desafio.
- **Facilidade de Teste**: Usar arquivos de entrada e saída permite testar diferentes cenários rapidamente, sem necessidade de interfaces complexas.
- **Portabilidade**: A abordagem funciona em qualquer ambiente com suporte a .NET, sem dependências adicionais.

## 🐞 **Debugging no VSCode**

Defini breakpoints nas áreas críticas do código, como:

- Validação de limites no método `IsWithinBounds` da classe `Plateau`.
- Processamento de comandos no Program.cs.
- Execução de comandos individuais (Execute nos comandos `MoveForwardCommand`, `RotateLeftCommand`, etc.).
- Durante a execução, inspecionei variáveis locais e propriedades das classes para verificar se os valores estavam corretos.
- Utilizei o recurso de "Step Over" (F10) para avançar linha a linha e identificar erros de lógica e validar o comportamento esperado do sistema.

O projeto inclui um arquivo `launch.json` configurado para depuração no **VSCode**. Para depurar:

1. Abra o VSCode na pasta do projeto.
2. Vá até a aba **Run & Debug**.
3. Escolha a configuração `C#: ExplorandoMarte Debug`.
4. Defina breakpoints no código e inicie a depuração (`F5`).

## 🔄 Pipeline de CI/CD

A integração contínua (CI) foi configurada usando **GitHub Actions** (`.github/workflows/ci.yml`). O pipeline executa:

1. **Checkout do código**
2. **Instalação do .NET SDK**
3. **Restauração de dependências**
4. **Compilação do projeto**
5. **Execução dos testes unitários**

Para visualizar os resultados:

1. Acesse a aba `Actions` no repositório do GitHub.
2. Verifique os logs detalhados para cada etapa.

## 🧪 Testes Unitários

Os testes foram implementados com **NUnit** e podem ser executados com:

```bash
dotnet test
```

Os principais cenários testados incluem:

- Mudança de direção (`L` e `R`)
- Movimentação válida e inválida
- Detecção de colisões
- Testes nas bordas do planalto

## 🎥 **Link para o Vídeo**

[Assista ao vídeo de execução do desafio aqui](https://youtu.be/0ncM-dJ2uWQ)

## 📜 Considerações Finais

Este projeto demonstra boas práticas de desenvolvimento em C#, aplicando conceitos de **POO**, **Design Patterns**, **SOLID** e **Testes Automatizados**. O código está organizado e pronto para futuras expansões! 🚀
