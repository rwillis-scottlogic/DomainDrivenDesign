using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Domain.Queries;

namespace DomainDrivenDesign.Example.Application.Queries;

public sealed class FindSpecificFriendHandler : IQueryHandler<FindSpecificFriend, FriendDetail?>
{
    public Task<FriendDetail?> Handle(FindSpecificFriend query)
    {
        /*
         * 
         * Directly query the underlying storage mechanism.
         *
         * e.g. SQL
         * SELECT * FROM [Friend] WHERE [Id] = @id
         * 
         */

        throw new NotImplementedException();
    }
}