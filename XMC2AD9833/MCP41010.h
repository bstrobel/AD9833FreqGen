/*
 * MCP41010.h
 *
 *  Created on: May 15, 2016
 *      Author: Bernd
 */

#ifndef MCP41010_H_
#define MCP41010_H_

#define MCP41010_BIT_C0 (4U + 8U)
#define MCP41010_BIT_C1 (5U + 8U)
#define MCP41010_BIT_P0 (0U + 8U)
#define MCP41010_BIT_P1 (1U + 8U)

void MCP41010_StartSPI(void);
void MCP41010_set(uint8_t value);

#endif /* MCP41010_H_ */
