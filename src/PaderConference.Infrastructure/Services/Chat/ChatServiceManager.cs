﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaderConference.Infrastructure.Services.Permissions;
using PaderConference.Infrastructure.Services.Synchronization;

namespace PaderConference.Infrastructure.Services.Chat
{
    public class ChatServiceManager : ConferenceServiceManager<ChatService>
    {
        private readonly ILogger<ChatService> _logger;
        private readonly IMapper _mapper;
        private readonly IOptions<ChatOptions> _options;

        public ChatServiceManager(IMapper mapper, IOptions<ChatOptions> options, ILogger<ChatService> logger)
        {
            _mapper = mapper;
            _options = options;
            _logger = logger;
        }

        protected override async ValueTask<ChatService> ServiceFactory(string conferenceId,
            IEnumerable<IConferenceServiceManager> services)
        {
            var permissionsService = await services.OfType<IConferenceServiceManager<PermissionsService>>().First()
                .GetService(conferenceId, services);
            var synchronizeService = await services.OfType<IConferenceServiceManager<SynchronizationService>>().First()
                .GetService(conferenceId, services);

            return new ChatService(conferenceId, _mapper, permissionsService, synchronizeService, _options, _logger);
        }
    }
}