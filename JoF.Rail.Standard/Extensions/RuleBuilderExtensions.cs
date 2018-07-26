namespace JoF.Rail.Standard.Extensions
{
    using FluentValidation;
    using JoF.Rail.Standard.Validators;

    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsValidCrsCode<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CrsCodeValidator());
        }
    }
}