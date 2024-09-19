import React from "react";
import { Box, Typography, Divider } from "@mui/material";

const Sidebar = () => (
  <Box
    sx={{
      width: 250,
      bgcolor: "rgba(200, 200, 245, 0.9)",
      height: "100vh",
      display: "flex",
      flexDirection: "column",
      p: 2,
      boxShadow: "2px 0 4px rgba(0, 0, 0, 0.2)",
    }}
  >
    <Typography variant="h6" sx={{ mb: 2, fontWeight: "bold" }}>
      Home Mgmt. | Menu
    </Typography>
    <Divider />
    <Box sx={{ mt: 2 }}>
      <Typography variant="body1" sx={{ mb: 1 }}>
        Home
      </Typography>
      <Typography variant="body1" sx={{ mb: 1 }}>
        Profile
      </Typography>
      <Typography variant="body1" sx={{ mb: 1 }}>
        Settings
      </Typography>
      <Typography variant="body1">Logout</Typography>
    </Box>
  </Box>
);

export default Sidebar;
