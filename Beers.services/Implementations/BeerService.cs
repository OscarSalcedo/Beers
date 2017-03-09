using Beers.Common.Const;
using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using Beers.Model;
using Beers.services.Contracts;
using Beers.services.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Beers.services.Implementations
{
    public class BeerService : ServiceBase, IBeerService
    {
        public BeerService()
        {

        }

        public List<BeerDto> GetAllBeers()
        {
            //var result = Context.Beer.ToList().ToBeerDtoList();

            if (Context.Beer.Any())
            {
                return Context.Beer.Include(i => i.BeerType).Include(i => i.Country).Include(i => i.City).ToBeerDtoList();
            }
            else
            {
                return null;
            }

        }

        public BeerDto GetBeerById(Guid beerId)
        {
            return FindWithInclude<Beer>(f => f.Id == beerId, GetIncludes()).ToBeerDto();
        }

        public List<BeerDto> GetBeerByFilter(FilterOptionsDto filterOptions)
        {
            if (filterOptions.Id == Guid.Empty && !string.IsNullOrWhiteSpace(filterOptions.StringFilter))
            {
                //****Just with name option
                //return Context.Beer.Where(w => w.Name == filterOptions.StringFilter).Include(i=> i.BeerType).Include(i=> i.Country).Include(i=> i.City).ToBeerDtoList();
                return WhereWithInclude<Beer>(w => w.Name == filterOptions.StringFilter, GetIncludes()).ToBeerDtoList();
            }
            else if (filterOptions.Id != Guid.Empty && string.IsNullOrWhiteSpace(filterOptions.StringFilter))
            {
                //****Just with type option
                //return Context.Beer.Where(w => w.BeerType.Id == filterOptions.Id).Include(i => i.BeerType).Include(i => i.Country).Include(i => i.City).ToBeerDtoList();
                return WhereWithInclude<Beer>(w => w.BeerType.Id == filterOptions.Id, GetIncludes()).ToBeerDtoList();
            }
            else if (filterOptions.Id != Guid.Empty && !string.IsNullOrWhiteSpace(filterOptions.StringFilter))
            {
                //****Both Filters
                //return Context.Beer.Where(w => w.BeerType.Id == filterOptions.Id && w.Name == filterOptions.StringFilter).Include(i => i.BeerType).Include(i => i.Country).Include(i => i.City).ToBeerDtoList();
                return WhereWithInclude<Beer>(w => w.BeerType.Id == filterOptions.Id && w.Name == filterOptions.StringFilter, GetIncludes()).ToBeerDtoList();
            }
            else
            {
                //Without Filters
                return GetAllBeers();
            }
        }

        public List<BeerDto> GetBeerByType(Guid typeId)
        {
            //return Context.Beer.Where(w => w.BeerType.Id == typeId).Include(i=>i.Country).Include(i=>i.City).Include(i=>i.BeerType).ToBeerDtoList();
            return WhereWithInclude<Beer>(w => w.BeerType.Id == typeId, GetIncludes()).ToBeerDtoList();
        }

        public List<BeerDto> GetBeerByName(string source)
        {
            //return Context.Beer.Where(w => w.Name.Contains(source)).Include(i=>i.BeerType).Include(i=>i.Country).Include(i=>i.City).ToBeerDtoList();
            return WhereWithInclude<Beer>(w => w.Name.Contains(source), GetIncludes()).ToBeerDtoList();
        }

        /*public BeerDto GetSingleBeerByName(string name)
        {
            var element = Context.Beer.Where(w => w.Name == name).Select(s => s.Id).First();
            //var id = element.ElementAt(0).ToString();
            return Context.Beer.Where(w => w.Id == element).Include(i => i.BeerType).Include(i => i.Country).Include(i => i.City).First().ToBeerDto();
        }*/

        public List<BeerDto> GetBeerByBeerType(Guid id)
        {
            return Context.Beer.Where(w => w.BeerType.Id == id).ToList().ToBeerDtoList();
        }

        public bool BeersAssignedToType(Guid id)
        {
            return GetBeerByBeerType(id).Any() ? true : false;

            //bool result = false;

            //if (GetBeerByBeerType(id).Any())
            //{
            //    result = true;
            //}

            //return result;
        }

        public bool ExistBeer(string name)
        {
            return Context.Beer.Any(w => w.Name == name);
        }

        public StateMessageDto CreateBeer(BeerDto beerDto)
        {

            var result = new StateMessageDto();

            if (ExistBeer(beerDto.Description.ToString()))
            {
                result.Message = GeneralConst.DuplicateName;
            }
            else
            {
                Guid id;
                id = Guid.NewGuid();
                beerDto.Code = id;


                var beer = beerDto.ToBeer();
                beer.Country = Context.Country.Find(beerDto.CountryId);
                beer.BeerType = Context.BeerType.Find(beerDto.BeerTypeId);
                beer.City = Context.City.Find(beerDto.CityId);
                Context.Beer.Add(beer);

                var resultContext = Context.SaveChanges();

                if (resultContext == 0)
                {
                    result.State = false;
                }
                else
                {
                    result.State = true;
                }
            }



            return result;
        }

        public int DeleteBeerById(Guid Id)
        {
            var BeerToDelete = Context.Beer.Find(Id);
            Context.Beer.Remove(BeerToDelete);
            return Context.SaveChanges();
        }

        public int UpdateBeer(BeerDto source)
        {
            var entityToModify = Context.Beer.Find(source.Code);
            entityToModify.Name = source.Description;
            entityToModify.Graduation = source.Graduation;
            entityToModify.Country = Context.Country.Find(source.CountryId);
            entityToModify.BeerType = Context.BeerType.Find(source.BeerTypeId);
            entityToModify.City = Context.City.Find(source.CityId);

            return Context.SaveChanges();
        }

        private List<Expression<Func<Beer,object>>> GetIncludes()
        {
            List<Expression<Func<Beer, object>>> result = new List<Expression<Func<Beer, object>>>();
            result.Add(a => a.BeerType);
            result.Add(a => a.City);
            result.Add(a => a.Country);
            return result;
        }

    }
}
