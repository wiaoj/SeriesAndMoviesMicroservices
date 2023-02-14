namespace BuildingBlocks.Core.Abstractions.Domain;

public interface IBusinessRule {
    public String Message { get; }
    public Boolean IsBroken();
}