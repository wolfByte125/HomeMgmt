import React from "react";
import dashboardImg from "../assets/images/login.jpg";
import {
  Box,
  Typography,
  Card,
  CardContent,
  Button,
  Divider,
  ButtonBase,
} from "@mui/material";
import stockImg from "../assets/images/groceries.jpg"; // Example image for Stock Management
import billImg from "../assets/images/bill.jpg"; // Example image for Bill Management
import plansImg from "../assets/images/plan.jpg"; // Example image for Plans Management
import usersImg from "../assets/images/users.jpg"; // Example image for User Management
import reportsImg from "../assets/images/report.jpg"; // Example image for Reports & Analytics
import Sidebar from "./Sidebar";

const Dashboard = () => {
  return (
    <Box
      display="flex"
      sx={{
        backgroundImage: `url(${dashboardImg})`,
        backgroundSize: "cover",
        backgroundPosition: "center",
      }}
    >
      <Sidebar />
      <Box display="flex" flexDirection="column" flex={1}>
        {/* <Box
          sx={{
            backgroundColor: "rgba(200, 200, 245, 0.9)",
            color: "#fff",
            padding: "32px 24px",
            // boxShadow: "0px 4px 8px rgba(0, 0, 0, 0.5)",
          }}
        ></Box> */}

        <Box
          display="flex"
          flexWrap="wrap"
          gap={2}
          justifyContent="space-around"
          alignItems="center"
          flex={1}
          padding={2}
        >
          <ButtonBase
            component="a"
            href="/stock-management"
            sx={{ width: "fit-content" }}
          >
            <Card
              sx={{
                width: 250,
                bgcolor: "#F5F5F5",
                boxShadow: 3,
                borderRadius: 4,
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                p: 2,
                transition: "transform 0.3s ease-in-out",
                "&:hover": {
                  transform: "scale(1.05)",
                  boxShadow: 6,
                },
              }}
            >
              <CardContent>
                <Typography variant="h5" gutterBottom textAlign={"center"}>
                  Stock Management
                </Typography>
                <Box
                  sx={{
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    marginBottom: 2, // Add some space between the image and the button
                  }}
                >
                  <img
                    src={stockImg}
                    alt="Reports & Analytics"
                    style={{ width: "50%", height: "auto" }}
                  />
                </Box>
                <Button variant="contained" color="secondary" fullWidth>
                  Go to Stock
                </Button>
              </CardContent>
            </Card>
          </ButtonBase>

          <ButtonBase
            component="a"
            href="/bill-management"
            sx={{ width: "fit-content" }}
          >
            <Card
              sx={{
                width: 250,
                bgcolor: "#F5F5F5",
                boxShadow: 3,
                borderRadius: 4,
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                p: 2,
                transition: "transform 0.3s ease-in-out",
                "&:hover": {
                  transform: "scale(1.05)",
                  boxShadow: 6,
                },
              }}
            >
              <CardContent>
                <Typography variant="h5" gutterBottom textAlign={"center"}>
                  Bill Management
                </Typography>
                <Box
                  sx={{
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    marginBottom: 2, // Add some space between the image and the button
                  }}
                >
                  <img
                    src={billImg}
                    alt="Reports & Analytics"
                    style={{ width: "50%", height: "auto" }}
                  />
                </Box>
                <Button variant="contained" color="secondary" fullWidth>
                  Go to Bills
                </Button>
              </CardContent>
            </Card>
          </ButtonBase>

          <ButtonBase
            component="a"
            href="/user-management"
            sx={{ width: "fit-content" }}
          >
            <Card
              sx={{
                width: 250,
                bgcolor: "#F5F5F5",
                boxShadow: 3,
                borderRadius: 4,
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                p: 2,
                transition: "transform 0.3s ease-in-out",
                "&:hover": {
                  transform: "scale(1.05)",
                  boxShadow: 6,
                },
              }}
            >
              <CardContent>
                <Typography variant="h5" gutterBottom textAlign={"center"}>
                  User Management
                </Typography>
                <Box
                  sx={{
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    marginBottom: 2, // Add some space between the image and the button
                  }}
                >
                  <img
                    src={usersImg}
                    alt="Reports & Analytics"
                    style={{ width: "50%", height: "auto" }}
                  />
                </Box>
                <Button variant="contained" color="secondary" fullWidth>
                  Manage Users
                </Button>
              </CardContent>
            </Card>
          </ButtonBase>

          <ButtonBase
            component="a"
            href="/reports-analytics"
            sx={{ width: "fit-content" }}
          >
            <Card
              sx={{
                width: 250,
                bgcolor: "#F5F5F5",
                boxShadow: 3,
                borderRadius: 4,
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                p: 2,
                transition: "transform 0.3s ease-in-out",
                "&:hover": {
                  transform: "scale(1.05)",
                  boxShadow: 6,
                },
              }}
            >
              <CardContent>
                <Typography variant="h5" gutterBottom textAlign={"center"}>
                  Reports & Analytics
                </Typography>
                <Box
                  sx={{
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    marginBottom: 2, // Add some space between the image and the button
                  }}
                >
                  <img
                    src={reportsImg}
                    alt="Reports & Analytics"
                    style={{ width: "50%", height: "auto" }}
                  />
                </Box>
                <Button variant="contained" color="secondary" fullWidth>
                  View Reports
                </Button>
              </CardContent>
            </Card>
          </ButtonBase>
        </Box>
      </Box>
    </Box>
  );
};

export default Dashboard;
