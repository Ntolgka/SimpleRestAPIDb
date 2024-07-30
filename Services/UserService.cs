using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Week2_Assignment.Interfaces;
using Week2_Assignment.Models;
using Week2_Assignment.Data;
using Week2_Assignment.Helpers;
using Week2_Assignment.Schema.Songs.Requests;
using Week2_Assignment.Schema.Songs.Responses;

namespace Week2_Assignment.Services;

public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserGetResponse>> GetAll()
        {
            var users = await _context.Users.OrderBy(x => x.Id).ToListAsync();
            return _mapper.Map<List<UserGetResponse>>(users);
        }

        public async Task<UserGetResponse> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException("There is no User with the given Id.");
            }

            return _mapper.Map<UserGetResponse>(user);
        }

        public async Task<List<UserGetResponse>> Create(UserCreateRequest userCreateRequest)
        {
            if (userCreateRequest == null)
            {
                throw new ArgumentNullException(nameof(userCreateRequest));
            }

            var user = _mapper.Map<User>(userCreateRequest);
            user.Password = CryptoHelper.CreateMD5(user.Password); // Hash the password

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserGetResponse>>(users);
        }

        public async Task<UserGetResponse> Update(UserUpdateRequest userUpdateRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userUpdateRequest.Id);
            if (user == null)
            {
                throw new KeyNotFoundException("There is no User with the given Id.");
            }

            _mapper.Map(userUpdateRequest, user);
            user.Password = CryptoHelper.CreateMD5(user.Password); // Hash the password

            await _context.SaveChangesAsync();

            return _mapper.Map<UserGetResponse>(user);
        }

        public async Task<UserGetResponse> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException("There is no User with the given Id.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserGetResponse>(user);
        }

        public async Task<UserGetResponse> Patch(int id, UserUpdateRequest updatedFields)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new KeyNotFoundException("There is no User with the given Id.");
            }

            _mapper.Map(updatedFields, user);
            user.Password = CryptoHelper.CreateMD5(user.Password); // Hash the password

            await _context.SaveChangesAsync();

            return _mapper.Map<UserGetResponse>(user);
        }

        public async Task<UserGetResponse> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user != null && user.Password == CryptoHelper.CreateMD5(password))
            {
                return _mapper.Map<UserGetResponse>(user);
            }
            return null;
        }
    }