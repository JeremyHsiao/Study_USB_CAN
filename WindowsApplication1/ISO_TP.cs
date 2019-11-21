using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsApplication1
{
    enum IsoTpProtocolControlInformation
    {
        ISOTP_PCI_TYPE_SINGLE = 0x0,
        ISOTP_PCI_TYPE_FIRST_FRAME = 0x1,
        TSOTP_PCI_TYPE_CONSECUTIVE_FRAME = 0x2,
        ISOTP_PCI_TYPE_FLOW_CONTROL_FRAME = 0x3
    };

    /* Private: Protocol Control Information (PCI) flow control identifiers. */
    enum IsoTpFlowStatus
    {
        PCI_FLOW_STATUS_CONTINUE = 0x0,
        PCI_FLOW_STATUS_WAIT = 0x1,
        PCI_FLOW_STATUS_OVERFLOW = 0x2
    };

    enum NetworkLayer_Result_Code
    {
        ISOTP_PROTOCOL_RESULT_OK = 0,
        ISOTP_PROTOCOL_RESULT_TIMEOUT_A = -1,
        ISOTP_PROTOCOL_RESULT_TIMEOUT_BS = -2,
        ISOTP_PROTOCOL_RESULT_TIMEOUT_CR = -3,
        ISOTP_PROTOCOL_RESULT_WRONG_SN = -4,
        ISOTP_PROTOCOL_RESULT_INVALID_FS = -5,
        ISOTP_PROTOCOL_RESULT_UNEXP_PDU = -6,
        ISOTP_PROTOCOL_RESULT_WFT_OVRN = -7,
        ISOTP_PROTOCOL_RESULT_BUFFER_OVFLW = -8,
        ISOTP_PROTOCOL_RESULT_ERROR = -9
    };

    class ISO_TP_Link
    {
        /* sender paramters */

        public UInt32 send_arbitration_id; /* used to reply consecutive frame */
        /* message buffer */
        //Byte* send_buffer;
        //uint16_t send_buf_size;
        UInt16 send_size;
        UInt16 send_offset;
        /* multi-frame flags */
        Byte send_sn;
        UInt16 send_bs_remain; /* Remaining block size */
        Byte send_st_min;    /* Separation Time between consecutive frames, unit millis */
        Byte send_wtf_count; /* Maximum number of FC.Wait frame transmissions  */
        UInt32 send_timer_st;  /* Last time send consecutive frame */
        UInt32 send_timer_bs;  /* Time until reception of the next FlowControl N_PDU; start at sending FF, CF, receive FC; end at receive FC */
        int send_protocol_result;
        Byte send_status;

        /* receiver paramters */
        uint receive_arbitration_id;
        /* message buffer */
        //Byte* receive_buffer;
        //UInt16 receive_buf_size;
        UInt16 receive_size;
        UInt16 receive_offset;
        /* multi-frame control */
        Byte receive_sn;
        Byte receive_bs_count; /* Maximum number of FC.Wait frame transmissions  */
        UInt32 receive_timer_cr; /* Time until transmission of the next ConsecutiveFrame N_PDU; start at sending FC, receive CF; end at receive FC */
        int receive_protocol_result;
        Byte receive_status;
    }

    public class ISO_TP
    {
        ISO_TP_Link iso_tp_link = new ISO_TP_Link();

        public int isotp_send(List<Byte> payload, UInt16 size)
        {
            return isotp_send_with_id(iso_tp_link.send_arbitration_id, payload, size);
        }

        public int isotp_send_with_id(UInt32 id, List<Byte> payload, UInt16 size) 
        {
            int ret = 0;

            //if (size > link->send_buf_size) {
            //    isotp_user_debug("Message size too large. Increase ISO_TP_MAX_MESSAGE_SIZE to set a larger buffer\n");
            //    char message[128];
            //    sprintf(&message[0], "Attempted to send %d bytes; max size is %d!\n", size, link->send_buf_size);
            //    return ISOTP_RET_OVERFLOW;
            //}


            return ret;
        }
    }
}
