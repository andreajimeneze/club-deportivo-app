using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System;

namespace ClubDeportivoApp.Utilidades
{
    public static class GeneradorContrato
    {
        public static void GenerarContrato(
            string nombre,
            string apellido,
            string dni,
            decimal montoCuota,
            int diaPago,
            string rutaArchivo)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);

                    page.Header()
                        .Text("CONTRATO DE SOCIO")
                        .FontSize(20)
                        .Bold()
                        .AlignCenter();

                    page.Content()
                        .PaddingVertical(20)
                        .Column(col =>
                        {
                            col.Spacing(10);

                            col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}");

                            col.Item().Text(
                                $"Se deja constancia que el cliente {nombre} {apellido}, DNI {dni}, " +
                                $"ha solicitado su inscripción como socio en el Club Deportivo."
                            );

                            col.Item().Text(
                                $"El valor de la cuota mensual asciende a ${montoCuota}."
                            );

                            col.Item().Text(
                                $"El socio se compromete a pagar el monto de la cuota los días {diaPago} de cada mes."
                            );

                            col.Item().Text(
                                "Si a la fecha de vencimiento no ha cancelado la cuota, quedará inactivo y no podrá acceder" +
                                "a ninguna actividad hasta ponerse al día."
                            );

                            col.Item().Text(
                                "El socio declara conocer y aceptar el reglamento interno del club."
                            );

                            col.Item().PaddingTop(40);

                            col.Item().Text(
                                "_____________________________________"
                            );

                            col.Item().Text(
                                "Firma del Socio"
                            );
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(txt =>
                        {
                            txt.Span("Club Deportivo - ");
                            txt.Span(DateTime.Now.Year.ToString());
                        });
                });
            })
            .GeneratePdf(rutaArchivo);
        }
    }
}