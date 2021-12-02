using FluentAssertions;
using Notifyre;
using Notifyre.Infrastructure.Utils;
using System;
using Xunit;

namespace NotifyreTests.Infrastructure.Utils
{
    public class UrlUtilTests
    {
        [Theory]
        [InlineData(null, "2021-09-01", "2021-09-02", ListSentFaxesRequestSortTypes.Asc, 10, "statustype=&fromdate=1630454400&todate=1630540800&sort=asc&limit=10")]
        [InlineData(null, null, null, null, null, "statustype=&fromdate=*&todate=*&sort=&limit=20")]
        [InlineData(ListSentFaxesRequestStatusTypes.Queued, null, null, ListSentFaxesRequestSortTypes.Desc, null, "statustype=queued&fromdate=*&todate=*&sort=desc&limit=20")]
        public void SerializeQuery_TestTheory(
            ListSentFaxesRequestStatusTypes? statusType,
            string fromDate,
            string toDate,
            ListSentFaxesRequestSortTypes? sort,
            int? limit,
            string result
        )
        {
            // Arrange
            var request = new ListSentFaxesRequest()
            {
                StatusType = statusType,
                Sort = sort,
            };
            if (!string.IsNullOrEmpty(fromDate)) request.FromDate = DateTime.Parse(fromDate).ToUnixTimeStamp();
            if (!string.IsNullOrEmpty(toDate)) request.ToDate = DateTime.Parse(toDate).ToUnixTimeStamp();
            if (limit != null) request.Limit = (int)limit;

            // Act
            var query = UrlUtil.SerializeQuery(request);

            // Assert
            query.Should().Match(result);
        }

        [Fact]
        public void SerializeQuery_TestEnum()
        {
            // Arrange
            var request = new ListGroupsRequest()
            {
                SearchQuery = null,
                SortDir = ListGroupsRequestSortTypes.asc,
                SortBy = ListGroupsRequestSortByTypes.DateCreated
            };

            // Act
            var query = UrlUtil.SerializeQuery(request);

            // Assert
            query.Should().Be("searchquery=&sortby=date_created&sortdir=asc");
        }

    }
}
