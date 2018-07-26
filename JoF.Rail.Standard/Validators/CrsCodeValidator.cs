namespace JoF.Rail.Standard.Validators
{
    using FluentValidation.Validators;

    public class CrsCodeValidator : PropertyValidator, ICrsCodeValidator
    {
        public CrsCodeValidator()
            : base("{PropertyValue} is an invalid station code")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null) return true;

            var crs = context.PropertyValue as string;

            if (crs == string.Empty) return true;

            if (crs.Length == 3) return true;

            context.MessageFormatter
                .AppendArgument("crs broke", crs);

            return false;
        }
    }

    public interface ICrsCodeValidator : IPropertyValidator
    {
    }
}
