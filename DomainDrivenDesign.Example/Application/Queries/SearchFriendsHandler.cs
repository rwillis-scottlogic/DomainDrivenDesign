using DomainDrivenDesign.Cqrs;
using DomainDrivenDesign.Example.Domain.Queries;

namespace DomainDrivenDesign.Example.Application.Queries;

public sealed class SearchFriendsHandler : IQueryHandler<SearchFriends, IEnumerable<FriendDetail>>
{
    public Task<IEnumerable<FriendDetail>> Handle(SearchFriends query)
    {
        /*
         * 
         * Directly query the underlying storage mechanism.
         *
         * e.g. SQL
         * SELECT * FROM [Friend] WHERE [Name] LIKE '%' + @nameMatch + '%'
         * 
         */

        throw new NotImplementedException();
    }
}