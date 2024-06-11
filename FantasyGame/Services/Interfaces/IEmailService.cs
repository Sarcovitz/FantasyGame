﻿using FantasyGame.Models.Entities;

namespace FantasyGame.Services.Interfaces;

public interface IEmailService
{
    /// <summary>
    ///     Register new user account.
    /// </summary>
    /// <param name="user"> <see cref="User"/> object to get e-mail details.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    /// <exception cref="Multiple exceptions"></exception>
    public Task SendAccountConfirmationEmailAsync(User user);
}
