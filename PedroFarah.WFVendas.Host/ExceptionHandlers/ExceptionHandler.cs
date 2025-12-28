using FluentValidation;
using System.Text;

namespace PedroFarah.WFVendas.Host.ExceptionHandlers
{

    public static class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            var message = ex.Message;

            if(ex is ValidationException validationEx)
            {
                var sb = new StringBuilder();

                var errors = string.Join("\n\r", validationEx.Errors.Select(x => x.ErrorMessage).ToArray());

                message = errors;
            }

            MessageBox.Show(
                message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

    }
}
