import React, { useState, useEffect } from "react";
import { DataGrid } from "@mui/x-data-grid";
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  TextField,
  Snackbar,
  IconButton,
} from "@mui/material";
import { Delete as DeleteIcon, Edit as EditIcon } from "@mui/icons-material";
import {
  useGetUsersQuery,
  useCreateUserMutation,
  useUpdateUserMutation,
  useDeleteUserMutation,
} from "../../features/api/apiSlice";

const UsersList = () => {
  const [users, setUsers] = useState([]);
  const [openDialog, setOpenDialog] = useState(false);
  const [editingUser, setEditingUser] = useState(null);
  const [snackbarOpen, setSnackbarOpen] = useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState("");
  const [newUser, setNewUser] = useState({ id: null, name: "", email: "" });
  const {
    data: usersList,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetUsersQuery();

  const [createUser] = useCreateUserMutation();
  const [updateUser] = useUpdateUserMutation();
  const [deleteUser] = useDeleteUserMutation();

  useEffect(() => {
    if (isSuccess) {
      setUsers(usersList);
    }
  }, [isSuccess, usersList]);

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (isError) {
    return <p>Error : {error.message}</p>;
  }

  const handleOpenDialog = (user) => {
    if (user) {
      setNewUser({ ...user });
    } else {
      const lastId = users.length > 0 ? Math.max(...users.map((u) => u.id)) : 0;
      setNewUser({ id: lastId + 1, name: "", email: "" });
    }
    setEditingUser(user);
    setOpenDialog(true);
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
  };

  const handleSaveUser = async () => {
    try {
      if (editingUser) {
        console.log(newUser);
        await updateUser(newUser).unwrap();
        setSnackbarMessage("User updated successfully!");
      } else {
        await createUser(newUser).unwrap();
        setSnackbarMessage("User added successfully!");
      }
    } catch (error) {
      setSnackbarMessage(`Error : ${error.message}`);
    }
    setSnackbarOpen(true);
    handleCloseDialog();
  };

  const handleDeleteUser = async (id) => {
    try {
      deleteUser({ id }).unwrap();
      setSnackbarMessage("User deleted successfully!");
    } catch (error) {
      setSnackbarMessage(`Error : ${error.message}`);
    }
    setSnackbarOpen(true);
  };

  const handleSnackbarClose = () => {
    setSnackbarOpen(false);
  };

  const columns = [
    { field: "name", headerName: "Name", width: 200 },
    { field: "email", headerName: "Email", width: 250 },
    {
      field: "actions",
      headerName: "Actions",
      width: 150,
      renderCell: (params) => (
        <>
          <IconButton
            color="primary"
            onClick={() => handleOpenDialog(params.row)}
          >
            <EditIcon />
          </IconButton>
          <IconButton
            color="secondary"
            onClick={() => handleDeleteUser(params.row.id)}
          >
            <DeleteIcon />
          </IconButton>
        </>
      ),
    },
  ];

  return (
    <div style={{ padding: "20px", textAlign: "center" }}>
      <h2>User Management</h2>

      {/* User List */}
      <div
        style={{
          marginBottom: "20px",
          display: "flex",
          justifyContent: "center",
        }}
      >
        <DataGrid rows={users} columns={columns} pageSize={5} />
      </div>

      {/* Add New User Button */}
      <Button
        variant="contained"
        color="primary"
        onClick={() => handleOpenDialog(null)}
      >
        Add New User
      </Button>

      {/* Dialog for Adding/Editing User */}
      <Dialog open={openDialog} onClose={handleCloseDialog}>
        <DialogTitle>{editingUser ? "Edit User" : "Add New User"}</DialogTitle>
        <DialogContent>
          <TextField
            label="Name"
            fullWidth
            margin="normal"
            value={newUser.name}
            onChange={(e) => setNewUser({ ...newUser, name: e.target.value })}
          />
          <TextField
            label="Email"
            fullWidth
            margin="normal"
            value={newUser.email}
            onChange={(e) => setNewUser({ ...newUser, email: e.target.value })}
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleCloseDialog} color="secondary">
            Cancel
          </Button>
          <Button onClick={handleSaveUser} color="primary">
            Save
          </Button>
        </DialogActions>
      </Dialog>

      {/* Snackbar for Success/Error Messages */}
      <Snackbar
        open={snackbarOpen}
        autoHideDuration={3000}
        onClose={handleSnackbarClose}
        message={snackbarMessage}
      />
    </div>
  );
};

export default UsersList;
