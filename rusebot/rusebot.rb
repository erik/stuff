require 'socket'

ruse = "~/Programming/d/ruse/ruse"
port = 6667
prepend = "@"
server = "irc.freenode.net"
chan = "#()"
nick = "rusebot"

@irc = TCPSocket.open(server, port)

def send(type, msg) 
    @irc.send("#{type} #{msg} \r\n", 0)
end

def send_message(to, msg)
    send("PRIVMSG", "#{to} :#{msg}")
end

send("USER", "rusebot * * :rusebot")
send("NICK", nick)
send("JOIN", chan)

loop do
    input = @irc.gets.chomp
    puts input
    if input
        if input.include? "PRIVMSG"
            msg = input.split(" :").last.chomp
            if msg[0] == prepend[0]
                cmd = `#{ruse} -e "#{msg[1..-1]}"`
                puts cmd
                send_message(chan, cmd)
            end
        end
    end
end
