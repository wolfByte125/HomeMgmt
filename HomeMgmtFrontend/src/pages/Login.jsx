import React from "react";
import loginImg from "../assets/images/login.jpg";
import { Box, TextField, Button, Typography } from "@mui/material";

const Login = () => {
  return (
    <Box
      display="flex"
      alignItems="center"
      justifyContent="flex-end" // Align form to the right
      height="100vh"
      position="relative"
      sx={{
        backgroundImage: `url(${loginImg})`,
        backgroundSize: "cover",
        backgroundPosition: "center",
        paddingRight: "10%", // Adjust padding to move the form more to the right
      }}
    >
      <Box
        width="100%"
        maxWidth="400px"
        p={4}
        bgcolor="rgba(255, 255, 255, 0.8)" // Semi-transparent white background
        boxShadow={3}
        borderRadius={4} // Rounded corners
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Typography
          variant="h4"
          gutterBottom
          textAlign="center"
          sx={{
            fontWeight: "bold",
            color: "#E07A5F", // Main color
            textShadow: "2px 2px 4px rgba(0, 0, 0, 0.2)", // Text shadow for a 3D effect
            mb: 3,
          }}
        >
          Login
        </Typography>

        <form
          noValidate
          autoComplete="off"
          sx={{
            width: "100%",
          }}
        >
          <TextField
            fullWidth
            label="Email"
            margin="normal"
            variant="outlined"
            sx={{
              "& .MuiOutlinedInput-root": {
                borderRadius: "25px",
                "& fieldset": {
                  borderColor: "#D8B4A6",
                },
                "&:hover fieldset": {
                  borderColor: "#A3D9FF",
                },
                "&.Mui-focused fieldset": {
                  borderColor: "#E07A5F",
                },
              },
              "& .MuiInputLabel-root": {
                color: "#D8B4A6",
              },
              "& .MuiInputLabel-root.Mui-focused": {
                color: "#E07A5F",
              },
            }}
          />
          <TextField
            fullWidth
            label="Password"
            margin="normal"
            variant="outlined"
            type="password"
            sx={{
              "& .MuiOutlinedInput-root": {
                borderRadius: "25px",
                "& fieldset": {
                  borderColor: "#D8B4A6",
                },
                "&:hover fieldset": {
                  borderColor: "#A3D9FF",
                },
                "&.Mui-focused fieldset": {
                  borderColor: "#E07A5F",
                },
              },
              "& .MuiInputLabel-root": {
                color: "#D8B4A6",
              },
              "& .MuiInputLabel-root.Mui-focused": {
                color: "#E07A5F",
              },
            }}
          />
          <Button
            variant="contained"
            sx={{
              bgcolor: "#E07A5F",
              borderRadius: "25px",
              "&:hover": {
                bgcolor: "#D8B4A6",
              },
              mt: 2,
              py: 1.5,
              fontWeight: "bold",
            }}
            fullWidth
          >
            Login
          </Button>
        </form>
      </Box>
    </Box>
  );
};

export default Login;
