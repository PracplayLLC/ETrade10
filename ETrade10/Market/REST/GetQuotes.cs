﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OkonkwoETrade10.Common;
using OkonkwoETrade10.Market;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API retrieves the quote information for one or more specified symbols.
      /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html
      /// </summary>
      /// <param name="symbols">Comma separated list of symbols list</param>
      /// <returns>A QuoteResponse object</returns>
      public static async Task<QuotesResponse> GetQuotesAsync(List<string> symbols)
      {
         string uri = ServerUri(EServer.Market) + $"quote/{GetCommaSeparatedString(symbols)}";

         var response = await MakeRequestAsync<QuotesResponse, QuotesErrorResponse>(uri);

         return response;
      }
   }

   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/QuoteResponse
   /// </summary>
   public class QuotesResponse : Response
   {
      /// <summary>
      /// The Quote Message Data
      /// </summary>
      public List<QuoteData> quoteData { get; set; }

      /// <summary>
      /// The Quote response Message
      /// </summary>
      public Messages messages { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class QuotesErrorResponse : ErrorResponse
   {
   }
}