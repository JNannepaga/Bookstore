// <copyright file="BookstoreController.cs" company="MalipsTech">
// Copyright (c) MalipsTech. All rights reserved.
// </copyright>

namespace Bookstore.Controllers
{
    using System.Threading.Tasks;
    using Bookstore.GraphqlBookstore.Models;
    using GraphQL;
    using GraphQL.NewtonsoftJson;
    using GraphQL.Types;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Class BookstoreController.
    /// <seealso cref="Controller"/>.
    /// </summary>
    [Route("graphql")]
    [ApiController]
    public class BookstoreController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookstoreController"/> class.
        /// </summary>
        /// <param name="schema">schema.</param>
        /// <param name="documentExecuter">documentExecuter.</param>
        public BookstoreController(
            ISchema schema,
            IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        /// <summary>
        /// GraphQl entry point.
        /// </summary>
        /// <param name="query">Queries.</param>
        /// <returns>Returns Queries.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookstoreQueryDto query)
        {
            var result = await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Variables = query.Variables?.ToInputs();
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result.Data);
        }
    }
}
