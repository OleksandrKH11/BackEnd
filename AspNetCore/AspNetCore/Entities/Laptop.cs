using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Entities
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string LaptomName { get; set; }

        public int Price { get; set; }
        public DateTime Date { get; set; }
        public object LaptopName { get; internal set; }
    }

    public class CreateLaptopCommandValidator : AbstractValidator<Laptop>
    {
        public CreateLaptopCommandValidator()
        {
            RuleFor(createNoteCommand =>
                createNoteCommand.UserName).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand =>
                createNoteCommand.LaptopName).NotEmpty();
            RuleFor(createNoteCommand =>
               createNoteCommand.Price).NotEmpty();
        }
    }
}
