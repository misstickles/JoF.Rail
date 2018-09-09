namespace JoF.Rail.Core.Extensions
{
    using FluentValidation;
    using JoF.Rail.Core.Validators;

    public static class RuleBuilderExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsValidCrsCode<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CrsCodeValidator());
        }
    }
}