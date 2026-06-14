using ClubDeportivoApp.Models;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace ClubDeportivoApp.Documentos
{
    public static class GeneradorCarnet
    {
        public static void GenerarPdfCarnet(Cliente socio, string ruta)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // Dimensiones tarjeta de crédito: 85.6 mm x 53.98 mm
            // En puntos (1 mm = 2.83465 puntos) -> 85.6 * 2.83465 ≈ 242.7 pt, 53.98 * 2.83465 ≈ 153 pt
            float anchoMm = 85.6f;
            float altoMm = 53.98f;
            float anchoPt = anchoMm * 2.83465f;
            float altoPt = altoMm * 2.83465f;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(anchoPt, altoPt);
                    page.Margin(5); // márgenes internos pequeños
                    page.Background(QuestPDF.Helpers.Colors.Grey.Lighten1);

                    page.Content()
                        .Border(1) // borde negro fino
                        .BorderColor(QuestPDF.Helpers.Colors.Blue.Medium)
                        .Padding(5)
                        .Column(col =>
                        {
                            col.Spacing(2);

                            // Línea superior: "Sistema de Gestión" (pequeño, centrado)
                            col.Item().AlignCenter().Text("Carnet de Socio").FontSize(10).Bold();

                            // Título principal "CLUB" (negrita, grande)
                            col.Item().AlignCenter().Text(@"CLUB DEPORTIVO ESTRELLA DEL SUR").FontSize(12).Bold();

                            // Espacio
                            col.Item().Height(32);
                            bool estaActivo = socio is Socio s && s.Estado;
                            // Datos del socio
                            col.Item().AlignCenter().Text($"Nombre: {socio.Nombre.ToUpper()} {socio.Apellido.ToUpper()}").FontSize(9).Bold();
                            col.Item().AlignCenter().Text($"DNI: {socio.Dni}").FontSize(9).Bold();
                            col.Item().AlignCenter().Text($"Estado: {(estaActivo ? "SOCIO ACTIVO" : "SOCIO INACTIVO")}").FontSize(9).Bold().FontColor(estaActivo ? QuestPDF.Helpers.Colors.Black : QuestPDF.Helpers.Colors.Black);

                            // Espacio
                            col.Item().Height(10);

                            // Pie: texto "Sistema de Gestión" pequeño o logo
                            //col.Item().AlignCenter().Text("Sistema de Gestión").FontSize(7).FontColor(QuestPDF.Helpers.Colors.Black);
                        });
                });
            });
        }

    }
}
