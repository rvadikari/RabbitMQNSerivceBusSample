C:\<OutSystems Install Folder>\thirdparty\RabbitMQ Server\rabbitmq_server-<version>\sbin
Enable the RabbitMQ management plugin
rabbitmq-plugins.bat enable rabbitmq_management
Check the service status
rabbitmqctl.bat status
Check the RabbitMQ service status
Execute the following commands to remove the currently running service, install a new one, and start it:
rabbitmq-service.bat remove
rabbitmq-service.bat install
rabbitmq-service.bat start
If the rabbitmq@<machine_name> node is not running, run the following command to start it:
rabbitmqctl.bat start_app
Run the following command:
rabbitmqctl.bat list_users
If the user it's not listed in the command output, run the following command to create it:
rabbitmqctl.bat add_user <admin_username> <admin_password>