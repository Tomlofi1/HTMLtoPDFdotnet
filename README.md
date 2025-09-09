📄 PdfHtmlGenerator

Projeto de exemplo em .NET que demonstra como implementar um Helper para gerar arquivos PDF a partir de templates HTML, utilizando o Syncfusion HTML to PDF.
O foco do projeto é mostrar como aplicar Reflection para substituir placeholders em templates HTML dinamicamente, com base em um DTO.

🚀 Funcionalidades

Conversão de HTML → PDF usando Syncfusion.

Substituição automática de placeholders ({{NomeDoCampo}}) por valores de um DTO, via Reflection.

Retorno do PDF como MemoryStream (ideal para integrar em APIs).

Estrutura simples para ser usada como Helper em outros projetos.

🛠️ Requisitos

.NET 6.0 ou superior (ajustar conforme a versão do projeto).

NuGet Package:

Install-Package Syncfusion.HtmlToPdfConverter.Net.Windows

📦 Estrutura do Projeto
PdfHtmlGenerator/
│
├── DTOs/
│   └── ExemploDTO.cs         # DTO com propriedades usadas como placeholders
│
├── Helpers/
│   └── PdfHelper.cs          # Classe principal responsável por gerar PDFs
│
├── Templates/
│   └── exemplo.html          # Template HTML com placeholders
│
└── Program.cs                # Exemplo de uso

🧩 Como funciona o Replace com Reflection?

O HTML contém placeholders como {{Nome}}, {{Data}}, etc.

O DTO (ex.: ExemploDTO) possui propriedades correspondentes.

O PdfHelper percorre as propriedades via Reflection e substitui os placeholders pelos valores do objeto.

Exemplo:

DTO

public class ExemploDTO
{
    public string Nome { get; set; }
    public DateTime Data { get; set; }
}


HTML (exemplo.html)

<html>
  <body>
    <h1>Olá, {{Nome}}!</h1>
    <p>Data de geração: {{Data}}</p>
  </body>
</html>


Saída PDF

Olá, Thomas!
Data de geração: 09/09/2025

📖 Exemplo de Uso
var dto = new ExemploDTO
{
    Nome = "Thomas",
    Data = DateTime.Now
};

var html = File.ReadAllText("Templates/exemplo.html");
var pdfStream = PdfHelper.GeneratePdfFromHtml(html, dto);

// Salvar em arquivo
using var fileStream = new FileStream("saida.pdf", FileMode.Create, FileAccess.Write);
pdfStream.CopyTo(fileStream);

📌 Observações

É necessário ter a licença do Syncfusion configurada para uso em produção.

Este projeto é apenas um exemplo educacional para demonstrar boas práticas de Helpers em .NET.
