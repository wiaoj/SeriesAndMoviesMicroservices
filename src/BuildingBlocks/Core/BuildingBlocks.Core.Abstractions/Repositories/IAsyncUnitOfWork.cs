namespace BuildingBlocks.Core.Abstractions.Repositories;

public interface IAsyncUnitOfWork {
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}