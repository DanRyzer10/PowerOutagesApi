using FluentValidation;
using AppLightBreaksSolution.DTOS;
namespace AppLightBreaksSolution.Validations
{
    public class QueryScheduleValidator:AbstractValidator<ScheduleDTO>
    {
        public QueryScheduleValidator()
        {
            string[] validTypes = { "IDENTIFICACION", "CUENTA_CONTRATO", "CUEN" };
            RuleFor(x => x.DocumentIdentification).NotEmpty().WithMessage("Numero de documento es requerido");
            RuleFor(x => x.DocumentIdentification).Length(7, 10).When(x => x.DocumentType == "IDENTIFICACION").WithMessage("Numero de documento debe tener entre 7 y 10 caracteres");
            RuleFor(x => x.DocumentIdentification).Length(9, 12).When(x => x.DocumentType == "CUENTA_CONTRATO").WithMessage("Numero de documento debe tener entre 9 y 10 caracteres");
            RuleFor(x => x.DocumentIdentification).Matches("^[a-zA-z][0-9]*$").When(x => x.DocumentType == "CUEN").WithMessage("El codigo unico debe ser numerico");
            RuleFor(x => x.DocumentType).Must(type => validTypes.Contains(type)).WithMessage("Opcion inválida-Valores permitidos ['CUEN->Codigo Unico','IDENTIFICACION->numero de cedula','CUENTA_CONTRATO->numero de cuenta contrato']");
            RuleFor(x => x.DocumentType).NotEmpty().WithMessage("Tipo de documento es requerido");
        }
    }
}
