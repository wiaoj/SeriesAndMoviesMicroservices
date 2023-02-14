using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace MovieService.Domain.Movie.ValueObjects;
public sealed class Rating : ValueObject {
    public Double Value { get; private set; }
    public Int64 Count { get; private set; }

    private Rating(Double value, Int32 ratingCount) {
        Value = value;
        Count = ratingCount;
    }

    public static Rating CreateNew(Double rating, Int32 ratingCount) {
        return new(rating, ratingCount);
    }

    public void AddNewRating(Rating rating) {
        Value = ((Value * Count) + rating.Value) / ++Count;
    }

    public void AddRangeNewRatings(List<Rating> ratings) {
        ratings.ForEach(rating => {
            AddNewRating(rating);
        });
    }

    public void RemoveRating(Rating rating) {
        Value = ((Value * Count) + rating.Value) / --Count;
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
        yield return Count;
    }
}