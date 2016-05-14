package whipsaw.server.messages;

import java.util.HashMap;
import java.util.Map;

import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.Session;

import org.apache.activemq.ActiveMQConnectionFactory;
import org.apache.activemq.command.ActiveMQTopic;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.jms.core.MessageCreator;

import com.fasterxml.jackson.databind.ObjectMapper;

public class MessageTopics {
	@Autowired
    ActiveMQConnectionFactory connectionFactory;

    @Autowired
    private ObjectMapper objectMapper;

    @Autowired
    private JmsTemplate statusUpdateJmsTemplate;

    private Map<String, ActiveMQTopic> topics = new HashMap<String, ActiveMQTopic>();


    public void createTopicAndTemplate(String name) {
        //If we don't have a topic we create it + a JmsTemplate
        if (topics.get(name) == null) {
            topics.put(name, new ActiveMQTopic(name));
        }
    }

    public void sendObjectAsJson(String topicName, Object object) {

        try {
            final String jsonString = objectMapper.writeValueAsString(object);
            statusUpdateJmsTemplate.send(topics.get(topicName), new MessageCreator() {
                public Message createMessage(Session session) throws JMSException {
                    return session.createTextMessage(jsonString);
                }
            });
        }
        catch (Exception ex) {
            ;
        }

    }
}
