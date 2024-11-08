using MediatR;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Application.Exceptions;
using System.Threading.Tasks;

namespace OnlineShop.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null) throw new NotFoundException("Category not found");

            category.Name = request.Name;
            category.Description = request.Description;
            await _categoryRepository.UpdateAsync(category);
            return Unit.Value;
        }
    }

}
