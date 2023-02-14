using BuildingBlocks.Core.Abstractions.Domain;

namespace BuildingBlocks.Core.Domain.Exceptions;

public class BusinessRuleValidationException : DomainException {
    public IBusinessRule BrokenRule { get; }

    public String Details { get; }
    public BusinessRuleValidationException(String errorMessage) : base(errorMessage) { }

    public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message) {
        BrokenRule = brokenRule;
        Details = brokenRule.Message;
    }

    public override String ToString() {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
    }
}
